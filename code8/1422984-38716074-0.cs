    [DataContract]
    public class Model
    {
        [DataMember]
        public int A { get; set; }
    
        [DataMember]
        public int B { get; set; }
    }
        
    [Route("API/Test"), HttpPost]
    public IHttpActionResult Test([FromUri] Model model)
