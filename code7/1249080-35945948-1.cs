    public class Foo
    {
        private CancellationTokenSource _cts;
        private Task _taskWeCanCancel;
    
        public Foo()
        {
            this._cts = new CancellationTokenSource();
    
            //This is where it's confusing. Passing the token here will only ensure that the task doesn't
            //run if it's canceled BEFORE it starts. This does not cancel the task during the operation of our code.
            this._taskWeCanCancel = new Task(this.FireTheTask, this._cts.Token);
        }
        /// <summary>
        /// I'm not a fan of returning tasks to calling code, so I keep this method void
        /// </summary>
        public void FireTheTask()
        {
            //Check task status here if it's required.
            this._taskWeCanCancel.Start();
        }
    
        public void CancelTheTask()
        {
            this._cts.Cancel();
        }
    
        /// <summary>
        /// Go and get something from the web, process a piece of data, execute a lengthy calculation etc...
        /// </summary>
        private async void OurTask()
        {
            Console.WriteLine("Do your work here and check periodically for task cancellation requests...");
    
            if (this._cts.Token.IsCancellationRequested) return;
    
            Console.WriteLine("Do another step to your work here then check the token again if necessary...");
    
            if (this._cts.Token.IsCancellationRequested) return;
    
            Console.WriteLine("Some work that we need to delegate to another task");
    
            await Some.Microsoft.Object.DoStuffAsync();
        }
    
    }
