    [DataContract]
    public class Poco
    {
        [DataMember(EmitDefaultValue = false)]
        public int DontEmitDefaultValue { get; set; }
    }
