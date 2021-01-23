    using System;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;
    using NLog;
    public class ExecutionTimeLogger : IDisposable
    {
        private readonly string methodName;
        private readonly ILog log = LogManager.GetLogger("ExecutionTimes");
        private readonly Stopwatch stopwatch;
        public ExecutionTimeLogger([CallerMemberName] string methodName = "")
        {
            this.methodName = methodName;
            stopwatch = Stopwatch.StartNew();
        }
        public void Dispose()
        {
            log.Debug(methodName + "() took " + stopwatch.ElapsedMilliseconds + " ms.");
            // Tells the garbage collector that a call to the finalizer of this object doesn't 
            // have to be scheduled, because we know it never created unmanaged resources.
            GC.SuppressFinalize(this);
        }
    }
