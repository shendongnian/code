    [JsonConverter(typeof(TolerantEnumConverter))]
    public enum FooEnumV1
    {
        OldMember,
        OldMember2,
    }
    [JsonConverter(typeof(TolerantEnumConverter))]
    public enum FooEnumV2
    {
        OldMember,
        OldMember2,
        NewMember
    }
