    using System;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;
    public class ExecutionTimeLogger : IDisposable
    {
        private readonly string methodName;
        private readonly Log log = new Log();
        private readonly Stopwatch stopwatch;
        public ExecutionTimeLogger([CallerMemberName] string methodName = "")
        {
            this.methodName = methodName;
            stopwatch = Stopwatch.StartNew();
        }
        public void Dispose()
        {
            log.Add(methodName + " took " + stopwatch.ElapsedMilliseconds + " ms");
        }
    }
