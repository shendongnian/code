    [DataContract] //found in System.Runtime.Serializatino
    public class ItemResult
    {
        [DataMember(Name = "id")] //Same place as DataContractAttribute
        public int Id { get; set; }
    }
