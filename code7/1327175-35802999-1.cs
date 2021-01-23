	[HttpGet]
	[ODataRoute("Employees(Name={name})")]
	public IHttpActionResult GetEmployeeByName([FromODataUri] string name)
	{
		var result = EmployeesHolder.Employees.FirstOrDefault(e => e.Name == name);
		if (result == null)
		{
			return this.NotFound();
		}
		return this.Ok(result);
	}
