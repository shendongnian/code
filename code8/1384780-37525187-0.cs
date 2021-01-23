    public sealed class MySynchronizationContextTaskScheduler : TaskScheduler {
        private readonly SynchronizationContext _synchronizationContext;
        public MySynchronizationContextTaskScheduler(SynchronizationContext context) {
            _synchronizationContext = context;
        }
        [SecurityCritical]
        protected override void QueueTask(Task task) {
            _synchronizationContext.Post(PostCallback, task);
        }
        [SecurityCritical]
        protected override bool TryExecuteTaskInline(Task task, bool taskWasPreviouslyQueued) {
            if (SynchronizationContext.Current == _synchronizationContext) {
                return TryExecuteTask(task);
            }
            else
                return false;
        }
        [SecurityCritical]
        protected override IEnumerable<Task> GetScheduledTasks() {
            return null;
        }
        public override Int32 MaximumConcurrencyLevel
        {
            get { return 1; }
        }
        private void PostCallback(object obj) {
            Task task = (Task) obj;
            base.TryExecuteTask(task);
        }
    }
