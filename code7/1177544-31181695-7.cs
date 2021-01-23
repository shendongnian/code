    public List<EmployeeTable> GetEmployees()
    {
    using(var ctx = new myEntities())
    {
        var cmd = ctx.Database.Connection.CreateCommand();
        cmd.CommandText = "[dbo].[SP_GetResult]";
        var reader = cmd.ExecuteReader(); 
        //reader.NextResult(); <- uncomment this to get second result(Customer)
        var employees = ((IObjectContextAdapter)db) 
            .ObjectContext 
            .Translate<EmployeeTable>(reader, "EmployeeTable", MergeOption.AppendOnly); 
        return employees;
    }
