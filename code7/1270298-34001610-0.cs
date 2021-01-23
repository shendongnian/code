        {"code":200,
    "description":{
     "15":{"id":"15","name":"US"},
     "25":{"id":"25","name":"Canada"}
     }}
        public class RootObject
        {
            public int code { get; set; }
            public Dictionary<string, NewCountry> description { get; set; }
        }
        public class NewCountry
        {
            public string id { get; set; }
            public string name { get; set; }
        }
