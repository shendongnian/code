     [ActionName("all")]
     [HttpGet]
     public IEnumerable<string> Get(string device_id, DateTime? date = null)
     {
          return new string[] { "value1", "value2" };
     }
    
     // GET api/values/5
     [ActionName("one")]
     [HttpGet]
     public string Get(string device_id, int id, DateTime? date = null)
     {
          return "value";
     }
