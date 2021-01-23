    internal static class ServiceTypeExtensions
    {
        public static Type[] GetServiceInterfaces(this Type serviceType)
        {
            List<Type> typeList = new List<Type>(((IEnumerable<Type>)serviceType.GetInterfaces()).Where(t => typeof(IService).IsAssignableFrom(t)));
            typeList.RemoveAll(t => t.GetNonServiceParentType() != null);
            return typeList.ToArray();
        }
        internal static Type GetNonServiceParentType(this Type type)
        {
            List<Type> typeList = new List<Type>(type.GetInterfaces());
            if (typeList.RemoveAll(t => t == typeof(IService)) == 0)
                return type;
            foreach (Type type1 in typeList)
            {
                Type serviceParentType = type1.GetNonServiceParentType();
                if (serviceParentType != null)
                    return serviceParentType;
            }
            return null;
        }
    }
