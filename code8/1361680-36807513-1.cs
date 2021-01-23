    public IEnumerable<NameDTO> Get(string Name = "")
    {
    var nameList = (from o in db.People.AsEnumerable()
                           where o.name.Equals(Name, StringComparison.OrdinalIgnoreCase)      
                           join s in db.Employee on
                            o.empID equals s.empID
                         
                            select new 
                            {
                                
                               s.empID,
                                o.Id
                            }).ToList();
    }    
