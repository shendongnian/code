    public class DerivedClassContractResolver : DefaultContractResolver
    {
        private Type _stopAtBaseType;
        public DerivedClassContractResolver(Type stopAtBaseType) 
        {
            _stopAtBaseType = stopAtBaseType;
        }
        protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
        {
            Type originalType = GetOriginalType(type);
            IList<JsonProperty> defaultProperties = base.CreateProperties(type, memberSerialization);
            List<string> includedProperties = Utilities.GetPropertyNames(originalType, _stopAtBaseType);
            return defaultProperties.Where(p => includedProperties.Contains(p.PropertyName)).ToList();
        }
        private Type GetOriginalType(Type type)
        {
            Type originalType = type;
            //If the type is a dynamic proxy, get the base type
            if (typeof(Castle.DynamicProxy.IProxyTargetAccessor).IsAssignableFrom(type))
                originalType = type.BaseType ?? type;
            return originalType;
        }
    }
    public class Utilities
    {
        /// <summary>
        /// Gets a list of all public instance properties of a given class type
        /// excluding those belonging to or inherited by the given base type.
        /// </summary>
        /// <param name="type">The Type to get property names for</param>
        /// <param name="stopAtType">A base type inherited by type whose properties should not be included.</param>
        /// <returns></returns>
        public static List<string> GetPropertyNames(Type type, Type stopAtBaseType)
        {
            List<string> propertyNames = new List<string>();
            if (type == null || type == stopAtBaseType) return propertyNames; 
            Type currentType = type;
            do
            {
                PropertyInfo[] properties = currentType.GetProperties(BindingFlags.Public | BindingFlags.DeclaredOnly | BindingFlags.Instance);
                foreach (PropertyInfo property in properties)
                    if (!propertyNames.Contains(property.Name))
                        propertyNames.Add(property.Name);
                currentType = currentType.BaseType;
            } while (currentType != null && currentType != stopAtBaseType);
            return propertyNames;
        }
    }
