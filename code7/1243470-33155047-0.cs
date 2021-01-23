    [DataContract(Name = "audit_value", Namespace = "")]
    public class AuditValue : IExtensibleDataObject
    {
        [DataMember(Name = "channel")]
        public int Channel { get; set; }
        
        [DataMember(Name = "week")]
        public Week Week { get; set; }
        public ExtensionDataObject ExtensionData { get; set; }
    }
    [DataContract(Name = "week", Namespace = "")]
    public class Week : IExtensibleDataObject
    {
        [DataMember(Name = "mo_th")]
        public Decimal MondayThroughThursday { get; set; }
        public ExtensionDataObject ExtensionData { get; set; }
    }
