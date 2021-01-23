    public class SlowClass
        {
            private object _lock;
            private static Data _cachedData;
            public SlowClass()
            {
                _lock = new object();
            }
    
            public Data GetData()
            {
                var task = new Task(DoStuffLongRun);
                task.Start();
                if (_cachedData == null)
                    task.Wait();
                return _cachedData;
            }
            public void DoStuffLongRun()
            {
    
                lock (_lock )
                {
                    Thread.Sleep(5000);//Do Long Stuff
                    _cachedData=new Data();
                }
        
            }
        }
