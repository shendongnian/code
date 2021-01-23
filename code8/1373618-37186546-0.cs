     public class RootObject
        {
            private object _data;
    
            public object data
            {
                get
                {
                    return _data;
                }
                set
                {
                    _data = JsonConvert.DeserializeObject<dataS>(value.ToString());
                }
            }
    
            public bool isAvial { get; set; }
            public string details { get; set; }
            public string id { get; set; }
        }
    
        public class dataS
        {
            public object SecureId { get; set; }
            public string FNAME { get; set; }
            public object MNAME { get; set; }
            public string LNAME { get; set; }
            public string POSTNAME { get; set; }
            public string DOB { get; set; }
            public string GENDER { get; set; }
            public object ORGID { get; set; }
        }
