    class Example
    {
        private DateTime _MyFunctionLastCallTime = DateTime.MinValue;
        private object _Lock;
        public void MyFunction()
        {
            lock(_Lock)
            {
                var now = DateTime.Now;
                if ((now - _MyFunctionLastCallTime).TotalSeconds < 3)
                    return;
                _MyFunctionLastCallTime = now;
                // the rest of code
            }
        }
    }
