﻿using FlaUI.Core;
using FlaUI.Core.Definitions;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Patterns;
using FlaUI.Core.Patterns.Infrastructure;
using FlaUI.Core.Tools;
using FlaUI.UIA3.Identifiers;
using UIA = interop.UIAutomationCore;

namespace FlaUI.UIA3.Patterns
{
    public class SynchronizedInputPattern : PatternBase<UIA.IUIAutomationSynchronizedInputPattern>, ISynchronizedInputPattern
    {
        public static readonly PatternId Pattern = PatternId.Register(AutomationType.UIA3, UIA.UIA_PatternIds.UIA_SynchronizedInputPatternId, "SynchronizedInput", AutomationObjectIds.IsSynchronizedInputPatternAvailableProperty);
        public static readonly EventId DiscardedEvent = EventId.Register(AutomationType.UIA3, UIA.UIA_EventIds.UIA_InputDiscardedEventId, "Discarded");
        public static readonly EventId ReachedOtherElementEvent = EventId.Register(AutomationType.UIA3, UIA.UIA_EventIds.UIA_InputReachedOtherElementEventId, "ReachedOtherElement");
        public static readonly EventId ReachedTargetEvent = EventId.Register(AutomationType.UIA3, UIA.UIA_EventIds.UIA_InputReachedTargetEventId, "ReachedTarget");

        public SynchronizedInputPattern(BasicAutomationElementBase basicAutomationElement, UIA.IUIAutomationSynchronizedInputPattern nativePattern) : base(basicAutomationElement, nativePattern)
        {
        }

        public ISynchronizedInputPatternEvents Events => Automation.EventLibrary.SynchronizedInput;

        public void Cancel()
        {
            ComCallWrapper.Call(() => NativePattern.Cancel());
        }

        public void StartListening(SynchronizedInputType inputType)
        {
            ComCallWrapper.Call(() => NativePattern.StartListening((UIA.SynchronizedInputType)inputType));
        }
    }

    public class SynchronizedInputPatternEvents : ISynchronizedInputPatternEvents
    {
        public EventId DiscardedEvent => SynchronizedInputPattern.DiscardedEvent;
        public EventId ReachedOtherElementEvent => SynchronizedInputPattern.ReachedOtherElementEvent;
        public EventId ReachedTargetEvent => SynchronizedInputPattern.ReachedTargetEvent;
    }
}
