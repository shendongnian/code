    public class FirstSmallInterceptor : Castle.DynamicProxy.IInterceptor
    {
        public FirstSmallInterceptor(IFirstSmallOne firstSmallOne) { ... }
    
        public void Intercept(IInvocation invocation)
        {
            if (invocation.Method.Name == nameof((IFirstSmallOne.FirstSomeMethod))
                invocation.ReturnValue = firstSmallOne.FirstSomeMethod(/* cast invocation.Arguments items */);
            else
                invocation.Proceed();
        }
    }
