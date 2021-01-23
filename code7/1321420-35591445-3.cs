    public HttpResponseMessage Post(Req model)
    {
        if (!ModelState.IsValid)
        {
           // to do  :return something. May be the validation errors?
        }
        // Model validation passed. Use model.Offset and Model.Limit as needed
        return Request.CreateResponse(HttpStatusCode.OK);
    }
