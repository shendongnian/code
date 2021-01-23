    public class dataC
    {
        public int SecureId { get; set; }
        public string FNAME { get; set; }
        public string  MNAME { get; set; }
        public string LNAME { get; set; }
        public string POSTNAME { get; set; }
        public string DOB { get; set; }
        public string GENDER { get; set; }
        public int ORGID { get; set; }
    }
    public class DataObj
        {
            public dataC data { get; set; }
            public bool isAvial { get; set; }
            public string details { get; set; }
            public string id { get; set; }
        }
    JsonConvert.DeserializeObject<List<DataObj>>(jsonstring);
