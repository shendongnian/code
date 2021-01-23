        [DataContract(Namespace = "")]
        public class YourClass
        {
            [DataMember(EmitDefaultValue = false, Name = "myVariable")]
            public string MyVariable { get; set; }
        }
