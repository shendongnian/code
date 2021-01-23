    using System;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;
    using log4net;
    public class ExecutionTimeLogger : IDisposable
    {
        private readonly ILog log = LogManager.GetLogger("ExecutionTimes");
        private readonly string methodName;
        private readonly Stopwatch stopwatch;
        public ExecutionTimeLogger([CallerMemberName] string methodName = "")
        {
            this.methodName = methodName;
            stopwatch = Stopwatch.StartNew();
        }
        public void Dispose()
        {
            log.Debug(methodName + "() took " + stopwatch.ElapsedMilliseconds + " ms.");
            GC.SuppressFinalize(this);
        }
    }
