    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Objects;
    using System.Data.Objects.DataClasses;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;
     
        public static class LinqExtensions
        {
            public static IQueryable<TSource> WhereLike<TSource>(
                this IQueryable<TSource> source,
                Expression<Func<TSource, string>> valueSelector,
                string value,
                char wildcard)
            {
                return source.Where(BuildLikeExpression(valueSelector, value, wildcard));
            }
     
            public static Expression<Func<TElement, bool>> BuildLikeExpression<TElement>(
                Expression<Func<TElement, string>> valueSelector,
                string value,
                char wildcard)
            {
                if (valueSelector == null)
                    throw new ArgumentNullException("valueSelector");
     
                var method = GetLikeMethod(value, wildcard);
     
                value = value.Trim(wildcard);
                var body = Expression.Call(valueSelector.Body, method, Expression.Constant(value));
     
                var parameter = valueSelector.Parameters.Single();
                return Expression.Lambda<Func<TElement, bool>>(body, parameter);
            }
     
            private static MethodInfo GetLikeMethod(string value, char wildcard)
            {
                var methodName = "Contains";
     
                var textLength = value.Length;
                value = value.TrimEnd(wildcard);
                if (textLength > value.Length)
                {
                    methodName = "StartsWith";
                    textLength = value.Length;
                }
     
                value = value.TrimStart(wildcard);
                if (textLength > value.Length)
                {
                    methodName = (methodName == "StartsWith") ? "Contains" : "EndsWith";
                    textLength = value.Length;
                }
     
                var stringType = typeof(string);
                return stringType.GetMethod(methodName, new Type[] { stringType });
            }
        }
