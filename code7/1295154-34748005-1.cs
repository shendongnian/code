    [HttpGet]
    public IHttpActionResult VerifyEmployee(string id)
    {
        var isValid = empRepository.VerifyEmployeeId(string id);
    
        return isValid ? Ok() : BadRequest("Some message");
    }
