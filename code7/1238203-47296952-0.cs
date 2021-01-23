    using System.ComponentModel.DataAnnotations;
    using System.Reflection;
    public static class PropertyExtension
    {
        public static string GetDisplayName<T>(this string property)
        {
            MemberInfo propertyInfo = typeof(T).GetProperty(property);
            var displayAttribute = propertyInfo?.GetCustomAttribute(typeof(DisplayAttribute)) as DisplayAttribute;
            return displayAttribute != null ? displayAttribute.Name : "";
        }
    }
    
