    [WebGet(UriTemplate = "{id}")]
    public HttpResponseMessage isTest(int id)
    {
       Model model = Model.table.Where(p => p.Id == id).FirstOrDefault();
       if (model != null)
       {
          //return Request.CreateResponse<Model>(HttpStatusCode.OK, model);
          //or
          return Request.CreateResponse(HttpStatusCode.OK, model);
       }
       else
       {
          return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Model Not Found");
       }
    }
