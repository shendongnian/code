    public class Foo
    {
        private CancellationTokenSource _cts;
    
        public Foo()
        {
            this._cts = new CancellationTokenSource();
        }
    
        public void StartExecution()
        {
            Task.Factory.StartNew(this.OwnCodeCancelableTask, this._cts.Token);
            Task.Factory.StartNew(this.OwnCodeCancelableTask_EveryNSeconds, this._cts.Token);
        }
    
        public void CancelExecution()
        {
            this._cts.Cancel();
        }
    
        /// <summary>
        /// "Infinite" loop with no delays. Writing to a database while pulling from a buffer for example.
        /// </summary>
        /// <param name="taskState">The cancellation token from our _cts field, passed in the StartNew call</param>
        private void OwnCodeCancelableTask(object taskState)
        {
            var token = (CancellationToken) taskState;
    
            while ( !token.IsCancellationRequested )
            {
                Console.WriteLine("Do your task work in this loop");
            }
        }
    
            
        /// <summary>
        /// "Infinite" loop that runs every N seconds. Good for checking for a heartbeat or updates.
        /// </summary>
        /// <param name="taskState">The cancellation token from our _cts field, passed in the StartNew call</param>
        private async void OwnCodeCancelableTask_EveryNSeconds(object taskState)
        {
            var token = (CancellationToken)taskState;
    
            while (!token.IsCancellationRequested)
            {
                Console.WriteLine("Do the work that needs to happen every N seconds in this loop");
    
                // Passing token here allows the Delay to be cancelled if your task gets cancelled.
                await Task.Delay(1000 /*Or however long you want to wait.*/, token);
            }
        }
    }
