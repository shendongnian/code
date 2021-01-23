    public class MyRequest
    {
      public string Name { set;get;}
    }
    [HttpPost]
    [Route("api/add")]
    public void Add([FromBody]MyRequest model)
    {
        //do something with model.Name
    }
