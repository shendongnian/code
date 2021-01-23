    using (DBContext ctx = new DBContext())
    {
        ctx.Connection.Open();
        
        List<EMPLOYEE> employees = (from e in ctx.EMPLOYEE 
                                    join d in ctx.Department on e.IdDepartment equals d.IdDepartment
                                    where d.NameDepartment.Contains("FINANCE")
                                    select e).ToList();
        ctx.Connection.Close();
    }
