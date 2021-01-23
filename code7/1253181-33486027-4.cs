    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;
    
    namespace MyNameSpace
    {
        public static TValue GetFieldAttributeValue<T, TOut, TAttribute, TValue>(
            string fieldName,
            Func<TAttribute, TValue> valueSelector)
            where TAttribute : Attribute
        {
            var fieldInfo = typeof(T).GetField(fieldName, BindingFlags.Public | BindingFlags.Static);
            if (fieldInfo == null)
            {
                return default(TValue);
            }
            var att = fieldInfo.GetCustomAttributes(typeof(TAttribute), true).FirstOrDefault() as TAttribute;
            return att != null ? valueSelector(att) : default(TValue);
        }
    }
