    [DataContract(Name = "AnotherPerson", Namespace = "Tests.FCTests")]
    public class AnotherPerson : IExtensibleDataObject
    {
        [DataMember]
        public string Name { get; set; }
        /* This is added in this version */
        [DataMember(Order = 2)]
        public Person FriendPerson { get; set; }
        public ExtensionDataObject ExtensionData { get; set; }
    }
