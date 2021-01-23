    public class Interceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            //Do before
            invocation.Proceed();
            //Do after
        }
    }
