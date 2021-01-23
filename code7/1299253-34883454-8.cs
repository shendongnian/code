    public static class MyExtentionMethods
    {
        public static void UseInterceptorFor<TObject,TInterceptor>(
            this IKernel kernel,
            Expression<Action<TObject>> methodExpr)
            where TInterceptor : IInterceptor
        {
            var interceptor = kernel.Get<TInterceptor>();
            kernel.InterceptReplace<TObject>(methodExpr, inv => interceptor.Intercept(inv));
        }
    }
