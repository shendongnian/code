    // With same index in list...
    for(int i=0;i<a.Count;i++)
    {
	    if(a[i].Name == b[i].Name)
	    {
		    // do something
	    }
    }
    // check each index in list a against list b
    List<Person> duplicates = a.Where(person_A => b.Any(person_B => person_A.Name === person_B.Name)).ToList();
    // check by index using lambda...
    List<Person> duplicates = a.Where(person_A, index => b[index].Name == person_A.Name).ToList();
 
