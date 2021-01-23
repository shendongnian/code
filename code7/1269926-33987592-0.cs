    static void AddPersons()
    {
    var unitOfWork = new UnitOfWork.UnitOfWork();    
    var motorcycle = unitOfWork.Motorcycles.GetById(1);
    motorcycle.Persons.Add(new Person{FirstName = "Jim", LastName = "Morrison"});
    unitOfWork.Commit()   
    }
   
