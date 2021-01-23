    public class SlowClass
    {
        private static object _lock;
        private static Data _cachedData;
        public SlowClass()
        {
            _lock = new object();
        }
        public void GetCachedData()
        {
            var task = new Task(DoStuffLongRun);
            task.Start();
            if (_cachedData == null)
                task.Wait();
        }
        public Data GetData()
        {
            if (_cachedData == null)
                GetCachedData();
            return _cachedData;
        }
        private void DoStuffLongRun()
        {
            lock (_lock)
            {
                Console.WriteLine("Locked Entered");
                Thread.Sleep(5000);//Do Long Stuff
                _cachedData = new Data();
            }
        }
    }
