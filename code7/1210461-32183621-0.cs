    [HttpGet]
    [Route("employee")]
    public IEnumerable<Employee> GetEmployees()
    {
        //code and return
    }
    [HttpGet]
    [Route("employee/{Id}")]
    public Employee GetSingleEmployee(int Id)
    {
        //code and return 
    }
