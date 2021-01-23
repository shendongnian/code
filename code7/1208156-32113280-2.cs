    public class AsyncFluent
    {
        /// Gets the task representing the fluent work.
        public Task Task { get; private set; }
        public AsyncFluent()
        {
            // The entry point for the async work.
            // Spin up a completed task to start with so that we dont have to do null checks    
            this.Task = Task.FromResult<int>(0);
        }
        /// Does A and returns the `this` current fluent instance.
        public AsyncFluent DoA()
        {
            QueueWork(DoAInternal);
            return this;
        }
        /// Does B and returns the `this` current fluent instance.
        public AsyncFluent DoB(bool flag)
        {
            QueueWork(() => DoBInternal(flag));
            return this;
        }
        /// Synchronously perform the work for method A.
        private void DoAInternal()
        {
            // do the work for method A
        }
        /// Synchronously perform the work for method B.
        private void DoBInternal(bool flag)
        {
            // do the work for method B
        }
        /// Queues up asynchronous work by an `Action`.
        private void QueueWork(Action work)
        {
            // queue up the work
            this.Task = this.Task.ContinueWith<AsyncFluent>(task =>
                {
                    work();
                    return this;
                }, TaskContinuationOptions.OnlyOnRanToCompletion);
        }
    }
