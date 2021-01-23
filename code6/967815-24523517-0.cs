        public static class TypeExtensions
        {
           public static IEnumerable<string> GetPropertyNames(this Type type)
           {
               return type.GetProperties().Select(p => p.Name);
           }
        }
