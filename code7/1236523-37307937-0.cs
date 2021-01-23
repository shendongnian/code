    using System;
    using System.Linq.Expressions;
    
    namespace ICSharpCode.SharpZipLib
    {
        public class NameOf
        {
            public static String nameof<T>(Expression<Func<T>> name)
            {
                MemberExpression expressionBody = (MemberExpression)name.Body;
                return expressionBody.Member.Name;
            }
        }
    }
