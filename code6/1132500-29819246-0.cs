    public static class ReflectionHelper
    {
        public static IEnumerable<PropertyInfo> GetPropertiesOfType<THolder, TPropType>()
        {
            return typeof(THolder).GetPropertiesOfType(typeof(TPropType));
        }
        public static IEnumerable<PropertyInfo> GetPropertiesOfType(this Type holderType, Type propType)
        {
            if (holderType == null)
                throw new ArgumentNullException("holderType");
            if (propType == null)
                throw new ArgumentNullException("propType");
            return holderType
                .GetProperties()
                .Where(prop =>
                    prop.PropertyType == propType); 
        }
        public static IEnumerable<Action<Func<TPropType, TPropType>>> CreateMutators<THolder, TPropType>(THolder holder)
        {
            if (holder == null)
                throw new ArgumentNullException("holder");
            return holder.GetType()
                .GetPropertiesOfType(typeof(TPropType))
                .Select(prop =>
                    new
                    {
                        getDelegate = (Func<TPropType>)Func<String>.CreateDelegate(typeof(Func<TPropType>), holder, prop.GetGetMethod()),
                        setDelegate = (Action<TPropType>)Action<String>.CreateDelegate(typeof(Action<TPropType>), holder, prop.GetSetMethod())
                    })
                .Select(accessor =>
                    (Action<Func<TPropType, TPropType>>)((mutate) =>
                    {
                        var original = accessor.getDelegate();
                        var mutated = mutate(original);
                        accessor.setDelegate(mutated);
                    }))
                .ToArray();
        }
    }
