    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Reflection;
    public static class ViewModelFactory
    {
        static readonly Type[] arguments = { typeof(string), typeof(string), typeof(string), typeof(int) };
        static readonly Dictionary<string, Func<string, string, string, int, object>>
        factoryCache = new Dictionary<string, Func<string, string, string, int, object>>();
        public static object CreateInstance(string typeName, string where, string select, string order, int take)
        {
            Func<string, string, string, int, object> factory;
            lock (factoryCache)
            {
                if (!factoryCache.TryGetValue(typeName, out factory))
                {
                    var type = Type.GetType(typeName);
                    var ci = type.GetConstructor(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance, null, arguments, null);
                    ParameterExpression par1 = Expression.Parameter(typeof(string), "par1");
                    ParameterExpression par2 = Expression.Parameter(typeof(string), "par2");
                    ParameterExpression par3 = Expression.Parameter(typeof(string), "par3");
                    ParameterExpression par4 = Expression.Parameter(typeof(int), "par4");
                    var exprNew = Expression.New(ci, par1, par2, par3, par4);
                    var lambda = Expression.Lambda<Func<string, string, string, int, object>>(exprNew, par1, par2, par3, par4);
                    factory = lambda.Compile();
                    factoryCache.Add(typeName, factory);
                }
            }
            return factory(where, select, order, take);
        }
    }
