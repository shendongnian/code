    [JsonConverter(typeof(StringEnumConverter))]
    public enum Status
    {
        [EnumMember(Value = "Awaiting Approval")]
        AwaitingApproval,
        Rejected,
        Accepted,
    }
