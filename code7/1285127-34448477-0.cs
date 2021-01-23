    class RequestRefLists
    {
        public List<Employee> EmployeeList {get;set;}
        public List<Dept> DeptList {get;set;}
    }
    
    public RequestRefLists GetRequestRefLists()
    {
        RequestRefLists ReqRefLists = new RequestRefLists();
    
        using(var context= new BusinessDBContext)
        { 
            var queryResult1 = from e in context.Employees
            select e;
            ReqRefLists.EmployeeList = queryResult1.Future();
    
            var queryResult2 = from d in context.Departments
            select d;
            ReqRefLists.DeptList = queryResult2.Future();        
        }
        return ReqRefLists;
    }
    Your queries will execute lazy on first enumeration of any collection.
