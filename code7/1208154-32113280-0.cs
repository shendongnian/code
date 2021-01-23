    public class AsyncFluent
    {
        /// <summary>
        /// Gets the task representing the fluent work.
        /// </summary>
        /// <value>
        /// The task.
        /// </value>
        public Task Task { get; private set; }
        public AsyncFluent()
        {
            /// <summary>
            /// The entry point for the async work.
            /// Spin up a completed task to start with 
            /// so that we dont have to do null checks    
            /// </summary>
            this.Task = Task.FromResult<int>(0);
        }
        /// <summary>
        /// Does A.
        /// </summary>
        /// <returns>This current fluent instance</returns>
        public AsyncFluent DoA()
        {
            QueueWork(DoAInternal);
            return this;
        }
        /// <summary>
        /// Does B.
        /// </summary>
        /// <param name="flag">An option!</param>
        /// <returns>This current fluent instance</returns>
        public AsyncFluent DoB(bool flag)
        {
            QueueWork(() => DoBInternal(flag));
            return this;
        }
        /// <summary>
        /// Synchronously perform the work for method A.
        /// </summary>
        private void DoAInternal()
        {
            // do the work for method A
        }
        /// <summary>
        /// Synchronously perform the work for method B.
        /// </summary>
        /// <param name="flag">An option!</param>
        private void DoBInternal(bool flag)
        {
            // do the work for method B
        }
        /// <summary>
        /// Queues up asynchronous work.
        /// </summary>
        /// <param name="work">The work to be queued.</param>
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
