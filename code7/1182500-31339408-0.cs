    public static class Invoke 
    {
        public static TimeSpan Measure(Action action)
        {
            if (action == null)
            { 
                throw new ArgumentNullException();
            }
  
            var stopWatch = Stopwatch.StartNew();
            action();
            stopWatch.Stop();
            return stopWatch.Elapsed;
        }  
    }
