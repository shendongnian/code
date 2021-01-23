    XmlArray("Data")]
    public class Data
    {
 	    [XmlArrayItem("PageInfo")]
        public List<PageInfo> pageInfos = new List<PageInfo>();
    }
    public class PageInfo
    {
        public int ID;
        public int NUM;
        public string URL;
    }
        
               
