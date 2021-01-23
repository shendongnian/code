    public class MyService
    {
        BlockingCollection<MyDto> sharedResource = new BlockingCollection<MyDto>();
        CancellationTokenSource cancellation;
        private Task producer;
        private List<Task> consumers;
        //Load/Set this from configuration
        private static readonly int MaxConsumer = 3;
    
        public void Start()
        {
            this.cancellation = new CancellationTokenSource();
            
            // Start the producer & Consumers, as long running task
            this.producer = Task.Factory.StartNew(() => this.Produce(), TaskCreationOptions.LongRunning);
            this.consumers = new List<Task>();
            for(int i=0; i<MaxConsumer; i++)
            {
                this.consumers.Add(Task.Factory.StartNew(() => this.Consume() , TaskCreationOptions.LongRunning));
            }
            
           // If you need primary service loop you can do 
           // something like the following
           // while(!this.cancellation.IsCancellationRequested)
           //{
           //        this.cancellation.Token.WaitHandle.WaitOne(1000);
           //}
        }
    
        public void Stop()
        {
            this.cancellation.Cancel();
            WaitOnTask(producer);
            foreach(var t in this.consumers)
            {
                WaitOnTask(t);
            }
            this.cancellation.Dispose();
        }
    
        private void WaitOnTask(Task task)
        {
            try
            {
                if (!task.IsCompleted)
                {
                    //May want to use timeout
                    //instead of blindly waiting
                    task.Wait();
                }
            }
            catch(ObjectDisposedException oex)           
            {
                // Task might have been disposed/closed already
            }
    
        }
    
        public void Produce()
        {
            var token = this.cancellation.Token;
            while(!token.IsCancellationRequested)
            {
                //Code for your data loading
                if (time to start)
                {
                    List<MyDto> rows = LoadData();
                    foreach(var data in rows)
                    {
                        this.sharedResource.Add(data, token);
                    }
                }
    
                //Wait and repeat
                token.WaitHandle.WaitOne(1000);
            }
        }
    
        public void Consume()
        {
            var token = this.cancellation.Token;
            try
            {
                foreach (var data in this.sharedResource.GetConsumingEnumerable(token))
                {
                    // Code for your data processing
                    Process(data);
                }
            }
            catch(OperationCanceledException ex)
            {
                // service stop requested, can log here
                // or take action for saving state as needed
            }
        }
    }
