    [DataContract] 
    public class Parent 
    {
        [DataMember(Name="id")]
        public int? Id { get; set; }
        [DataMember(Name = "value")]
        public int? Value { get; set; }
    }
