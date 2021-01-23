    Public void SelectValues()
    {
        using (Entities1 entity = new Entities1())
        {
           var Employees = entity.SP_GetResult;
           var Customers = Employees.GetNextResult<Customer>();
           // do your stuff
        }
    } 
