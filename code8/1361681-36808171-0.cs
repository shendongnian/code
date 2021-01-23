    var nameList= db.People.AsEnumerable();
                People people = new People();
                foreach (var x in nameList)
                {
                    var result = x.name.ToLower() == Name.ToLower();
                    if (result)
                    {
                        people = x;
                    }
                }
    
    var Employee =  db.Employee.FirstOrDefault(e => e.EmpId == people.EmpId);
    
    NameDTO nameDTO = new NameDTO()
    {
     EmpId = Employee.EmpId,
     Id = People.Id
    };
