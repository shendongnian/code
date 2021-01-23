        [JsonConverter(typeof(JsonToStringConverter))]
        public class IPAddress
        {
            private byte[] bytes;
            public override string ToString()
            {
                return "192.168.1.2";
            }
        }
