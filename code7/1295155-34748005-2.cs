    [HttpPut]
    public IHttpActionResult Update(EmployeeViewModel model)
    {
        if(!empRepository.VerifyEmployeeId(model.Id))
            return BadRequest("Some error message");
    
        empRepository.Update(model);
        return Ok();
    }
