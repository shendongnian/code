    public class DataObj
    {
        public string isAvial { get; set; }
        public string details { get; set; }
        public string id { get; set; }
        public DataTable data { get; set; } 
    } 
    var desc = JsonConvert.DeserializeObject<List<DataObj>>(jsonstring);
