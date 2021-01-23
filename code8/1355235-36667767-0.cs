    public class xPTTriggerListener : TriggerListenerSupport {
        public override string Name
        {
            get { return "xPTTriggerListener"; }
        }
        public override void TriggerComplete(ITrigger trigger, IJobExecutionContext context, SchedulerInstruction triggerInstructionCode) {
            if (triggerInstructionCode == SchedulerInstruction.DeleteTrigger) {
                // means this trigger won't be fired again - now recalculate your dates in database
            }
            base.TriggerComplete(trigger, context, triggerInstructionCode);
        }
    }
