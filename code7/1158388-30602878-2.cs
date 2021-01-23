    using System.Linq;
    using FastMember;
    
    namespace Utilities
    {
        public static class CheckStringProperties
        {
            public static bool AreAnyStringPropertiesNull<T>(this T model) where T : class
            {
                var accessor = TypeAccessor.Create(model.GetType());
                return AreAnyStringPropertiesNull(model, accessor);
            }
            public static bool AreAnyStringPropertiesNull<T>(this T model) where T : class
            {
                var accessor = TypeAccessor.Create(model.GetType());
                return AreAllStringPropertiesNull(model, accessor);
            }
    
            private static bool AreAnyStringPropertiesNull<T>(T model, TypeAccessor accessor)
            {
    			foreach (var strng in GetStringProperties(accessor))
    			{
    				if (string.IsNullOrWhiteSpace(strng))
    					return true;
    			}
    			
    			return false;
            }
            private static bool AreAllStringPropertiesNull<T>(T model, TypeAccessor accessor)
            {
    			foreach (var strng in GetStringProperties(accessor))
    			{
    				if (!string.IsNullOrWhiteSpace(strng))
    					return true;
    			}
    			
    			return false;
            }
    
            private static List<Member> GetStringProperties(TypeAccessor accessor)
            {
                return accessor.GetMembers().Where(x => x.Type == typeof(string)).ToList();
            }
        }
    }
