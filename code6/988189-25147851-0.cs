    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class EnumOrderAttribute : Attribute
    {
        public int Order { get; set; }
    }
    
    
    public static class EnumExtenstions
    {
        public static IEnumerable<string> GetWithOrder(this Enum enumVal)
        {
            return enumVal.GetType().GetWithOrder();
        }
    
        public static IEnumerable<string> GetWithOrder(this Type type)
        {
            if (!type.IsEnum)
            {
                throw new ArgumentException("Type must be an enum");
            }
            // caching for result could be useful
            return type.GetFields()
                                   .Where(field => field.IsStatic)
                                   .Select(field => new
                                                {
                                                    field,
                                                    attribute = field.GetCustomAttribute<EnumOrderAttribute>()
                                                })
                                    .Select(fieldInfo => new
                                                 {
                                                     name = fieldInfo.field.Name,
                                                     order = fieldInfo.attribute != null ? fieldInfo.attribute.Order : 0
                                                 })
                                   .OrderBy(field => field.order)
                                   .Select(field => field.name);
        }
    }
