    public interface ILogger
    {
        void Log(string message);
    }
    [Serializable]
    public class LogMethodAspect : OnMethodBoundaryAspect
    {
        private ILogger logger;
        public override void RuntimeInitialize(MethodBase method)
        {
            this.logger = // get the shared logger instance
        }
        public override void OnEntry(MethodExecutionArgs args)
        {
            // ...
            this.logger.Log("Entering: " + method_name + arg_values);
        }
    }
    class Class1
    {
        [LogMethodAspect]
        void Method1 (input1, input2)
        {
            // Do Something
            // using the same shared logger
            logger.Log("Log this info")
            // Do Something more
        }   
    }
