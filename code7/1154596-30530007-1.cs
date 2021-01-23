    [AttributeUsage(AttributeTargets.Parameter)]
    public sealed class AutoTaskAttribute : CustomizeAttribute
    {
        private readonly int progress;
        private readonly TaskState taskState;
        public AutoTaskAttribute(TaskState taskState, int progress = -1)
        {
            this.taskState = taskState;
            this.progress = progress;
        }
        public override ICustomization GetCustomization(ParameterInfo parameter)
        {
            var customization = new TypeCustomization<Task>().With("TaskState", this.taskState);
            if (this.progress > -1)
            {
                customization.With("Progress", this.progress);
            }
            return customization;
        }
    }
