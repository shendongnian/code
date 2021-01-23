    public static class TypeExtensions
    {
        public static bool IsDerivedFromGenericParent(this Type type, Type parentType)
        {
    		if(!parentType.IsGenericType)
    		{
    			throw new ArgumentException("type must be generic", "parentType");
    		}
            if(type == null || type == typeof(object))
            {
                return false;
            }
            if(type.IsGenericType && type.GetGenericTypeDefinition() == parentType)
            {
                return true;
            }
        	return type.BaseType.IsDerivedFromGenericParent(parentType)
    		    || type.GetInterfaces().Any(t=>t.IsDerivedFromGenericParent(parentType));
        }
    }
