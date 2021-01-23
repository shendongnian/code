    public void Post(long id, [FromBody]VariableTemplateViewModel model)
    {
        if (!ModelState.IsValid && TryValidateModel(model.NestedModel, "NestedModel."))
        {
            throw new HttpResponseException(HttpStatusCode.BadRequest);
        }   
    }
