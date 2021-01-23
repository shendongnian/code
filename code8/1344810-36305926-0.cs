    // serialize only marked members
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class SerializableObject
    {
        // original property: not serialized
        public TypeA PropertyA { get; set; }
        [JsonProperty(nameof(PropertyA))]
        public TypeB PropertyB
        {
            get
            {
                // convert PropertyA value to TypeB
                return (TypeB)PropertyA;
            }
            set
            {
                // convert TypeB to TypeA and set PropertyA value
                PropertyA = (TypeA)value;
            }
        }
    }
