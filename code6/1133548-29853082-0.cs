    [RoutePrefix("api/query")
    public QueryController: ApiController
    {
      [Route("{id}/{param}")]
      public string Get(int id, string param)
      {
          string output = "";
          output = JsonConvert.SerializeObject(null);
          return output;
      }
    
      // GET api/query/5
      [Route("{id}")]
      public string Get(int id)
      {
          return "value";
      }
    }
