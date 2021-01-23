     var keys= mydictionary.Select(s => s.Key);
     var query=Context.Persons.Where(t => keys.Contains(t.Id));
     foreach(var person in query)
     {
       person.Salary=mydictionary[person.Id];
     }
     Context.SaveChanges();
     
