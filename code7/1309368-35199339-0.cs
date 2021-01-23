    public class ParObj
    {
        public string v {get;set;}
        public string y {get;set;}
    }
    
    var paramObj = JsonConvert.DeserializeObject<ParObj>(context.Request["XXXX"]);
