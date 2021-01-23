    public static class TypeExtensions
    {
        public static bool IsGenericSubClassOf(this Type type, Type parentType)
        {
        	if(type == typeof(object))
            {
                return false;
            }
        	if(type.IsGenericType && type.GetGenericTypeDefinition() == parentType)
            {
                return true;
            }
        	return type.BaseType.IsGenericSubClassOf(parentType);
        }
    }
