    public IHttpActionResult Create(UserViewModel vewModel)
    {
    	var validator = new UserValidator();
        if (validator.validate(vewModel).IsValid)
        {
            return Ok();
        }
        return BadRequest();
    }
