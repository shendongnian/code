    using(var unit=new UnitOfWork())
    {
        var person= new Person(){Name:"Peter"};
        unit.BeginTrans();
        var personFilled=unit.Persons.Add(person);
        Console.Out.WriteLine("Person id is:" + personFilled.Id);
        unit.Save();//you end transaction if all works as expected
         
        //if something went wrong you can call unit.RollBack()
        // and it will discard previous SaveChanges call inside Repo      
    }
   
    
 
