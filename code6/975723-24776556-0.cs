    public class WData{
        public string Item {get;set;}
        public int Entry {get;set;}
    }
    public class RQuery
    {
        public string item { get; set; }
        public string entry { get; set; }
    }
    public IHttpActionResult Get ([FromUri] RQuery query)
    {
        WData data = new WData();
        if (!String.IsNullOrEmpt(query.item))
            data.Item = "Test";
        if (!String.IsNullOrEmpt(query.entry))
            data.Entry = 2;
        return Ok(data );  
    }
