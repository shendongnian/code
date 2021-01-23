    public static class TypeExtensions
    {
        public static bool IsGenericSubClassOf(this Type type, Type parentType)
        {
            if(type == null || type == typeof(object))
            {
                return false;
            }
            if(type.IsGenericType && type.GetGenericTypeDefinition() == parentType)
            {
                return true;
            }
        	return type.BaseType.IsGenericSubClassOf(parentType)
    		    || type.GetInterfaces().Any(t => t.IsGenericSubClassOf(parentType));
        }
    }
