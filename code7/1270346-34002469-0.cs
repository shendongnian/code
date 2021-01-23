    public class COLUMNSANDDATA
    {
        public List<string> COLUMNS { get; set; }
        public List<List<object>> DATA { get; set; }
    }
    
    public class RootObject
    {
        public int SUCCESS { get; set; }
        public string ERRMSG { get; set; }
        public COLUMNSANDDATA COLUMNSANDDATA { get; set; }
    }
    var deserializer = new JavaScriptSerializer();
    var jsonObj = deserializer.DeserializeObject<RootObject>(result);
    
    foreach(col in jsonObj.COLUMNSANDDATA.COLUMNS)
    {
        //...
    }
