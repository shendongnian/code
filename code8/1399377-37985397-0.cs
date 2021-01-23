    [Route("index")]
    [Route("index/{id}")]
    public JsonResult index(int id = null)
    {
    
        if(id.HasValue()){
          return new JsonResult {Data = 'test2'};
        }
    
        return new JsonResult {Data = 'test1'};
    }
