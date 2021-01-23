    public IHttpActionResult Get(int id)
    {
      //create response_data
      
      new System.Threading.Tasks.Task(() =>
      {
        //do the logging
      }).Start();
      return Content(HttpStatusCode.Accepted, response_data);
    }
