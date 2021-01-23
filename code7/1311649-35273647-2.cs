    public class Foo
    {
        private struct InternalEFData
        {
            public int SomeProperty;
        }
    
    
        private CancellationTokenSource _dataCreatorCts;
        private CancellationTokenSource _efCts;
    
        //In case you care about what tasks you have.
        private List< Task > _tasks;
        private Task _entityFrameworkTask;
    
        private ConcurrentBag< InternalEFData > _efData;
    
    
        public Foo()
        {
            this._efData = new ConcurrentBag< InternalEFData >();
    
            this._dataCreatorCts = new CancellationTokenSource();
            this._efCts = new CancellationTokenSource();
    
            this._entityFrameworkTask = Task.Factory.StartNew(this.ProcessEFData, this._efCts.Token);
    
            this._tasks.Add(Task.Factory.StartNew(this.Method1, this._dataCreatorCts.Token));
            this._tasks.Add(Task.Factory.StartNew(this.Method2, this._dataCreatorCts.Token));
            .
            .
            .
    
        }
    
        private void ProcessEFData(object state)
        {
            var token = (CancellationToken) state;
            while ( !token.IsCancellationRequested )
            {
                InternalEFData item;
                if (this._efData.TryTake(out item))
                {
                    using ( var efContext = new MyDbContext() )
                    {
                        //Do processing.    
                    }
                }
            }
    
        }
    
        private void Method1(object state)
        {
            var token = (CancellationToken) state;
            while ( !token.IsCancellationRequested )
            {
                //Get data from whatever source
                this._efData.Add(new InternalEFData());
            }
    
        }
    
        private void Method2(object state)
        {
            var token = (CancellationToken) state;
            while ( !token.IsCancellationRequested )
            {
                //Get data from whatever source
                this._efData.Add(new InternalEFData());
            }
        }
    
    
        public void StopExecution()
        {
            this._dataCreatorCts.Cancel();
            this._efCts.Cancel();
        }
    }
