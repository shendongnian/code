    [Serializable]
    sealed class FactoryClassAttribute : Attribute {
        public FactoryClassAttribute(Type type) {
            Type = type;
        }
    
        public Type Type { get; set; }
    
        public static FactoryClassAttribute From(Enum value) {
        {
            var type = value.GetType();
            return type.GetField(Enum.GetName(type, value))
                .GetCustomAttributes(false)
                .OfType<FactoryClassAttribute>()
                .FirstOrDefault();
        }    
    }
