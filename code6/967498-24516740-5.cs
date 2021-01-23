    using System;
    using System.Linq.Expressions;
    using Castle.DynamicProxy;
    using SimpleInjector;
    public static class InterceptorExtensions
    {
        private static readonly ProxyGenerator generator = new ProxyGenerator();
        private static readonly Func<Type, object, IInterceptor, object> createProxy =
            (p, t, i) => generator.CreateInterfaceProxyWithTarget(p, t, i);
        public static void InterceptWith<TInterceptor>(this Container c, 
            Predicate<Type> predicate)
            where TInterceptor : class, IInterceptor
        {
            c.ExpressionBuilt += (s, e) =>
            {
                if (predicate(e.RegisteredServiceType))
                {
                    var interceptorExpression = 
                        c.GetRegistration(typeof(TInterceptor), true).BuildExpression();
                    e.Expression = Expression.Convert(
                        Expression.Invoke(Expression.Constant(createProxy),
                            Expression.Constant(e.RegisteredServiceType, typeof(Type)),
                            e.Expression,
                            interceptorExpression),
                        e.RegisteredServiceType);
                }
            };
        }
    }
