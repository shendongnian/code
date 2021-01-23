    public HttpResponseMessage Post(Req model)
    {
        if (!ModelState.IsValid)
        {
           // to do  :return something. May be the validation errors?
            var errors = new List<string>();
            foreach (var modelStateVal in ModelState.Values.Select(d => d.Errors))
            {
                errors.AddRange(modelStateVal.Select(error => error.ErrorMessage));
            }
            return Request.CreateResponse(HttpStatusCode.OK, new { Status = "Error", 
                                                                           Errors = errors });
        }
        // Model validation passed. Use model.Offset and Model.Limit as needed
        return Request.CreateResponse(HttpStatusCode.OK);
    }
