    public class DataInfo
    {
        public string EditType { get; set; }
        public string CustCode { get; set; }
        public string KeyNoStr { get; set; }
        public string Requester { get; set; }
        public string VerificationCode { get; set; }
        public string Databody { get; set; }
        public bool HasMap { get; set; }
        public bool IsColse { get; set; }
        public bool HasOrder { get; set; }
        public bool IsUrgent { get; set; }
    }
    
    public class RootObject
    {
        public List<DataInfo> DataInfo { get; set; }
    }
    //your method
    public void ProcessRequest(HttpContext context)
    {
        Request = context.Request;
        Response = context.Response;
        string lv_strResult = string.Empty;
        DataInfo lv_oInfo = JsonConvert.DeserializeObject<RootObject>((new StreamReader(Request.InputStream)).ReadToEnd());
     }
