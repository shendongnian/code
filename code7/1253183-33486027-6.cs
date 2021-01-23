    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;
    
    public static class AttributeHelper
    {
        public static TOut GetConstFieldAttributeValue<T, TOut, TAttribute>(
            string fieldName,
            Func<TAttribute, TOut> valueSelector)
            where TAttribute : Attribute
        {
            var fieldInfo = typeof(T).GetField(fieldName, BindingFlags.Public | BindingFlags.Static);
            if (fieldInfo == null)
            {
                return default(TOut);
            }
            var att = fieldInfo.GetCustomAttributes(typeof(TAttribute), true).FirstOrDefault() as TAttribute;
            return att != null ? valueSelector(att) : default(TOut);
        }
    }
