    // myQuery is an IQueryable from a different context
    // This did not work
    IEnumerable<Person> result = db.People.Where(p => myQuery.ToList().Contains(p.Id)).ToList();
    // This worked
    myList = myQuery.ToList();
    IEnumerable<Person> result = db.People.Where(p => myList.Contains(p.Id)).ToList(); 
