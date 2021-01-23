    public class Foo
    {
        private object _efLock;
        public Foo()
        {
            this._efLock = new object();
        }
    .
    .
    .
        private void MethodX(object state)
        {
            var token = (CancellationToken)state;
            while (!token.IsCancellationRequested)
            {
                lock(this._efLock)
                {
                     using(.......
                }
            }
        }
    }
