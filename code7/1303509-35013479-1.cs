    class Example
    {
        private DateTime _MyFunctionLastCallTime = DateTime.MinValue;
        private object _Lock = new object();
        public void MyFunction()
        {
            lock(_Lock)
            {
                var now = DateTime.UtcNow;
                if ((now - _MyFunctionLastCallTime).TotalSeconds < 3)
                    return;
                _MyFunctionLastCallTime = now;
                // the rest of code
            }
        }
    }
