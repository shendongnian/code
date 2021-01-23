    public class SomeDto
    {
        public string Name { get; set; }
    }
    
    [Route("somedto"), HttpPost]
    public void PostDto([FromBody]SomeDto value)
    {
            
    }
