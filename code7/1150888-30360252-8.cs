    public class BigDataClass
    {
        private List<string> data = new List<string>();
        [ScriptIgnore]
        public List<string> Data { get { return data; } } // note, we removed the setter
        public string SerializedData { get { JavaScriptSerializer jss = new JavaScriptSerializer(); return jss.Serialize(data); } set { JavaScriptSerializer jss = new JavaScriptSerializer(); data = jss.Deserialize<List<string>>(value); } }
    }
