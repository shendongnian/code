    public IEnumerable<Employee> Get(int departmentID)
    {
        var isDepartmentValid = CheckIfDepartmentIsAccessible(username, departmentID);
        if (!isDepartmentValid)
        {
            throw new HttpResponseException(HttpStatusCode.Forbidden);
        }
    
        return Request.CreateResponse(HttpStatusCode.OK, GetEmployees(departmentID));
    }
