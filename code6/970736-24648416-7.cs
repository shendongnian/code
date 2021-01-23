	[HttpGet]
	[ODataRoute("GetReports(Id={Id},Year={Year})")]
	public IHttpActionResult WhateverName([FromODataUri]int Id, [FromODataUri]int Year)
	{
		return Ok(_reportsRepository.GetReports(Id, Year));
	}
    
