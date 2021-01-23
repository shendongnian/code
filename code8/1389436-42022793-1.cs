    /// <summary>
    /// Short, descriptive title of the operation
    /// </summary>
	/// <remarks>
	/// More elaborate description
	/// </remarks>
    /// <param name="id">Here is the description for ID.</param>
	[ProducesResponseType(typeof(Bar), (int)HttpStatusCode.OK)]
    [HttpGet, Route("{id}", Name = "GetFoo")]
    public async Task<IActionResult> Foo([FromRoute] long id)
    {
    	var response = new Bar();
    	return Ok(response);
    }
