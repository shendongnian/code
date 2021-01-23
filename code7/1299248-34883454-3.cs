    public static class MyExtentionMethods
    {
        public static void UseInterceptorFor<T>(
            this IKernel kernel,
            Expression<Action<T>> methodExpr,
            IInterceptor interceptor)
        {
            kernel.InterceptReplace<T>(methodExpr, inv => interceptor.Intercept(inv));
        }
    }
