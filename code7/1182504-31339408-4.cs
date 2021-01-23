    public static class Invoke 
    {
        // Func<T> instead of Action
        public static Timed<T> Measure(Func<T> func)
        {
            if (func== null)
            { 
                throw new ArgumentNullException();
            }
  
            var stopWatch = Stopwatch.StartNew();
            var result = func();
            stopWatch.Stop();
            return Timed.Create(result, stopWatch.Elapsed);
        }  
    }
