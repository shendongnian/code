    foreach (var person in pi.People)
    {
        var myLookup =
            myLookups
            .SingleOrDefault(a =>
                a.OldSite == person.Site
                && a.OldDepartment == person.Deparment);
        
        if (myLookup == null)
        {
            // Handle a missing lookup accordingly.
            throw new Exception("Where is my lookup?!");
        }
        
        person.Site = myLookup.NewSite;
        person.Deparment = myLookup.NewDepartment;
    }
