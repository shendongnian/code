    [JsonConverter(typeof(StringEnumConverter))]
    public enum MyEnum
    {
        [EnumMember(Value = "Type One")]
        TypeOne,
        [EnumMember(Value = "Type Two")]
        TypeTwo,
        [EnumMember(Value = "Type Three")]
        TypeThree
    }
