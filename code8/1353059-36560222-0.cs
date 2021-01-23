    public class ObjectOverrideContractResolver : DefaultContractResolver
    {
        readonly HashSet<Type> overrideObjectTypes;
        public ObjectOverrideContractResolver(IEnumerable<Type> overrideObjectTypes)
        {
            if (overrideObjectTypes == null)
                throw new ArgumentNullException();
            this.overrideObjectTypes = new HashSet<Type>(overrideObjectTypes);
        }
        protected override JsonContract CreateContract(Type objectType)
        {
            if (overrideObjectTypes.Contains(objectType))
            {
                var contract = CreateObjectContract(objectType);
                // Mark get-only properties like Count as ignored 
                foreach (var property in contract.Properties)
                {
                    if (!property.Writable)
                        property.Ignored = true;
                }
                return contract;
            }
            else
            {
                var contract = base.CreateContract(objectType);
                return contract;
            }
        }
    }
