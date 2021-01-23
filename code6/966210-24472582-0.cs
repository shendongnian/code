        [DataContract]
        public class IPAddress
        {
            private byte[] bytes;
            // Added this readonly property to allow serialization
            [DataMember(Name = "ipValue")]
            public string Value
            {
                get
                {
                    return this.ToString();
                }
            }
            
            public override string ToString()
            {
                return "192.168.1.2";
            }
        }
