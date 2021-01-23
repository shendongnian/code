        public class Relay
        {
            public int GPIO { get; set; }
            public int id { get; set; }
            public int status { get; set; }
            public string type { get; set; }
        }
        public class RelayCollection
        {
            public Relay[] relays { get; set; }
        
        }
