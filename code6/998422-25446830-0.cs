        public void Intercept(IInvocation invocation)
        {
            // Calls the decorated instance.
            invocation.Proceed();
            var classIntercepted = invocation.InvocationTarget;
            MethodInfo method = invocation.InvocationTarget.GetType().GetMethod("SetConnectionString");
            method.Invoke(classIntercepted, null);
        }
