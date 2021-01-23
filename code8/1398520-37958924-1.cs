    [DataContract]
    public class SerializeMe
    {
        [IgnoreDataMember]
        public DoNotSerializeMe CannotBeSerializedDirectly;
        [DataMember]
        DoNotSerializeMeSurrogate DoNotSerializeMeSurrogate
        {
            get
            {
                if (CannotBeSerializedDirectly == null)
                    return null;
                return new DoNotSerializeMeSurrogate { WhyAmIHereSurrogate = CannotBeSerializedDirectly.WhyAmIHere };
            }
            set
            {
                if (value == null)
                    CannotBeSerializedDirectly = null;
                else
                    CannotBeSerializedDirectly = new DoNotSerializeMe(value.WhyAmIHereSurrogate);
            }
        }
        [DataMember]
        public string SomeOtherField { get; set; }
    }
    [DataContract]
    class DoNotSerializeMeSurrogate
    {
        [DataMember]
        public string WhyAmIHereSurrogate { get; set; }
    }
 
