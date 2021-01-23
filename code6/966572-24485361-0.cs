    public class ClassForJson
        {
            public string key { get; set; }
            public Value value{ get; set; }
            public class Value
            {
                public string name { get; set; }
                public string description { get; set; }
                public string version { get; set; }
            }
        }
