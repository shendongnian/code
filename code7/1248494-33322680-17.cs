    [JsonConverter(typeof(JsonDerivedTypeConverer<IField>), new object [] { new Type [] { typeof(Field1), typeof(Field2) } })]
    public interface IField
    {
        string Name { get; set; }
    }
