    [Route("myApiGetRequest")]
    [HttpGet]
    [MyExceptionFilter]
    public IHttpActionResult myApiGetRequest(long id)
    {
        DataTable transaction = new DataTable();
        using (var context = new myDbContext())
        {
             //code for what I want to do
        }
    }
