    public IEnumerable<Employee> Get(int departmentID)
    {
       try
       {
          return GetEmployees(departmentID);
       }
       catch(Exception ex) //assuming invalid dept or unauthorized throw Argument & Security Exceptions respectively
       {
            if(ex is SecurityException)
                throw new HttpResponseException(HttpStatusCode.Forbidden);
            else if(ex is ArgumentException)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            else
                 //handle or throw actual unhandled exception
        }
    }
