    [Serializable]
    [DataContract(IsReference = true)]
    public class ProvisioningUserType : Entity, IUserType
    {
        [DataMember]
        public string Alias { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public IEnumerable<string> Permissions { get; set; }
    }
