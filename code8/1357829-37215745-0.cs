    [Serializable]
    public class MaxMysqlConnectionExceptionHandlerAspect : OnExceptionAspect
    {
        public override void OnException(MethodExecutionArgs args)
        {
            if (args.Exception.InnerException != null && args.Exception.InnerException.Message.Contains("Too many connections"))
            {
                args.FlowBehavior = FlowBehavior.ThrowException;
                args.Exception = new Exception("MAX_CONNECTIONS");
            }
        }
        public override Type GetExceptionType(MethodBase method)
        {
            return typeof(EntityException);
        }
    }
