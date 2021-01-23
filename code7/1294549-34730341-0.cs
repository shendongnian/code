    [HttpGet]
    [Route("api/myClasses/GetTypes")]
    public myClasses.Type[] GetTypes()
    {
        return empRepository.GetAllTypes();
    }
    [HttpGet]
    [Route("api/myClasses/GetEmployees")]
     public myClasses.Employee[] GetEmployees()
    {
        return empRepository.GetAllEmployees();
    }
