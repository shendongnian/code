    [AttributeUsage(AttributeTargets.Property)]
    class JsonPropertyGenericTypeNameAttribute : Attribute
    {
        public int TypeParameterPosition { get; }
        
        public JsonPropertyGenericTypeNameAttribute(int position)
        {
            TypeParameterPosition = position;
        }
    }
