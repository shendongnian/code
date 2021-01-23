    var list = John.Employees.ToList();
    
    list.Insert(0,
        new Person
        {
            Name = John.Name,
            Department =  John.Department,
            Gender = John.Gender
        });
