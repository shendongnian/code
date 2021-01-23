    [HttpPut]
    public HttpResponseMessage Update(EmployeeViewModel model)
    {
        if(!empRepository.VerifyEmployeeId(model.Id))
            return new HttpResponseMessage(HttpStatusCode.BadRequest);
    
        empRepository.Update(model);
        return new HttpResponseMessage(HttpStatusCode.OK);
    }
    [HttpGet]
    public HttpResponseMessage VerifyEmployee(string id)
    {
        var isValid = empRepository.VerifyEmployeeId(string id);
    
        return isValid ? new HttpResponseMessage(HttpStatusCode.OK) : new HttpResponseMessage(HttpStatusCode.BadRequest);
    }
