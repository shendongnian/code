    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;
    
    namespace MyNameSpace
    {
        public static class AttributeHelper
        {
            public static TValue GetFieldAttributeValue<T, TOut, TAttribute, TValue>(
                Expression<Func<T, TOut>> fieldExpression, 
                Func<TAttribute, TValue> valueSelector) 
                where TAttribute : Attribute
            {
                var expression = (MemberExpression) fieldExpression.Body;
                var fieldInfo = (FieldInfo) expression.Member;
                var att = fieldInfo.GetCustomAttributes(typeof(TAttribute), true).FirstOrDefault() as TAttribute;
                return att != null ? valueSelector(att) : default(TValue);
            }
        }
    }
