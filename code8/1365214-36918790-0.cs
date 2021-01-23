    public class ConstructorPropertiesOnlyContractResolver : DefaultContractResolver
    {
        readonly bool serializeAllWritableProperties;
        public ConstructorPropertiesOnlyContractResolver(bool serializeAllWritableProperties)
            : base()
        {
            this.serializeAllWritableProperties = serializeAllWritableProperties;
        }
        protected override JsonObjectContract CreateObjectContract(Type objectType)
        {
            var contract = base.CreateObjectContract(objectType);
            if (contract.CreatorParameters.Count > 0)
            {
                foreach (var property in contract.Properties)
                {
                    if (contract.CreatorParameters.GetClosestMatchProperty(property.PropertyName) == null)
                    {
                        if (!serializeAllWritableProperties || !property.Writable)
                            property.Readable = false;
                    }
                }
            }
            return contract;
        }
    }
