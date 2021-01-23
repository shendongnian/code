    [HttpPost]
    public IActionResult Insert([FromBody]Agent agent)
    {
        if (!ModelState.IsValid)
        {
		    var errors = ModelState
                .SelectMany(x => x.Value.Errors, (y, z) => z.Exception.Message);
			return BadRequest(errors);
        }
        // Model is valid, do stuff.
    }
