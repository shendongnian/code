    List<Employee> empList = new ApplicationDbContext().Employee.ToList();
    List<OtherTable> othrList= new OtherDbContext().OtherTable.ToList();
    
    var returnValue = (from e in empList 
                            join o in othrList on e.Id equals o.Id
                            select new
                            {
                                e.Name,
                                e.Address,
                                o.Others
                            });
