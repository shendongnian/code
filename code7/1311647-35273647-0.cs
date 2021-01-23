    public class Foo
    {
        private CancellationTokenSource _cts;
        //In case you care about what tasks you have.
        private List< Task > _tasks;
    
        public Foo()
        {
            this._cts = new CancellationTokenSource();
    
            this._tasks.Add(Task.Factory.StartNew(this.Method1, this._cts.Token));
            this._tasks.Add(Task.Factory.StartNew(this.Method2, this._cts.Token));
            this._tasks.Add(Task.Factory.StartNew(this.Method3, this._cts.Token));
            this._tasks.Add(Task.Factory.StartNew(this.Method4, this._cts.Token));
    
    
        }
    
        private void Method1(object state)
        {
            var token = (CancellationToken) state;
            while ( !token.IsCancellationRequested )
            {
                //do stuff
            }
    
        }
        private void Method2(object state)
        {
            var token = (CancellationToken)state;
            while (!token.IsCancellationRequested)
            {
                //do stuff
            }
        }
        private void Method3(object state)
        {
            var token = (CancellationToken)state;
            while (!token.IsCancellationRequested)
            {
                //do stuff
            }
        }
        private void Method4(object state)
        {
            var token = (CancellationToken)state;
            while (!token.IsCancellationRequested)
            {
                //do stuff
            }
        }
    
        public void StopExecution()
        {
            this._cts.Cancel();
        }
    }
