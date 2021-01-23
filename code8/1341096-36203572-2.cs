        public class Script
        {
            public string script_name { get; set; }
            public string dir { get; set; }
            public string destination { get; set; }
            public string @params { get; set; }
        }
        public class Config
        {
            public Script script { get; set; }
        }
        public class RootObject
        {
            public Config config { get; set; }
        }
