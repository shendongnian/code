    class InheritingTask: TaskBase
    {
        public InheritingTask()
            : base(Settings.Default.InheritingTaskInterval) // In milliseconds
        {
            //TODO: Custom initialization here
        }
        protected override void Tick()
        {
            //TODO: Task logic here
        }
        protected override void OnStart()
        { }
        protected override void OnStop()
        { }
        protected override void ResetTimer()
        {
            //TODO: Custom reset logic here
            base.ResetTimer();
        }
    }
