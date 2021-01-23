        public class SerializableExpandableContractResolver : DefaultContractResolver
        {
            public static readonly SerializableExpandableContractResolver Instance = new SerializableExpandableContractResolver();
    
            protected override JsonContract CreateContract(Type objectType)
            {
                if (TypeDescriptor.GetAttributes(objectType).Contains(new TypeConverterAttribute(typeof(ExpandableObjectConverter))))
                {
                    return CreateObjectContract(objectType);
                }
                return base.CreateContract(objectType);
            }
        }
