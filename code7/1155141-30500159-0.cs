    [Serializable]
    [DebuggerStepThrough]
    [AttributeUsage(AttributeTargets.Method)]
    public sealed class LogExecutionTimeAttribute : OnMethodInvocationAspect
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(LogExecutionTimeAttribute));
     
        // If no threshold is provided, then just log the execution time as debug
        public LogExecutionTimeAttribute() : this (int.MaxValue, true)
        {
        }
        // If a threshold is provided, then just flag warnning when threshold's exceeded
        public LogExecutionTimeAttribute(int threshold) : this (threshold, false)
        {
        }
        // Greediest constructor
        public LogExecutionTimeAttribute(int threshold, bool logDebug)
        {
            Threshold = threshold;
            LogDebug = logDebug;
        }
     
        public int Threshold { get; set; }
        public bool LogDebug { get; set; }
     
        // Record time spent executing the method
        public override void OnInvocation(MethodInvocationEventArgs eventArgs)
        {
            var sw = Stopwatch.StartNew();
            eventArgs.Proceed();
            sw.Stop();
            var timeSpent = sw.ElapsedMilliseconds;
     
            if (LogDebug)
            {
                Log.DebugFormat(
                    "Method [{0}{1}] took [{2}] milliseconds to execute",
                    eventArgs.Method.DeclaringType.Name,
                    eventArgs.Method.Name,
                    timeSpent);
            }
     
            if (timeSpent > Threshold)
            {
                Log.WarnFormat(
                    "Method [{0}{1}] was expected to finish within [{2}] milliseconds, but took [{3}] instead!",
                    eventArgs.Method.DeclaringType.Name,
                    eventArgs.Method.Name,
                    Threshold,
                    timeSpent);
           }
    }
