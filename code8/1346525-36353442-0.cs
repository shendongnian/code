    using (AdventureWorksEntities context = new AdventureWorksEntities())
    {
        // Create a query that takes two parameters.
        string queryString =
            @"SELECT VALUE Contact FROM AdventureWorksEntities.Contacts 
                    AS Contact WHERE Contact.LastName = @ln AND
                    Contact.FirstName = @fn";
    
        ObjectQuery<Contact> contactQuery =
            new ObjectQuery<Contact>(queryString, context);
    
        // Add parameters to the collection.
        contactQuery.Parameters.Add(new ObjectParameter("ln", "Adams"));
        contactQuery.Parameters.Add(new ObjectParameter("fn", "Frances"));
    
        // Iterate through the collection of Contact items.
        foreach (Contact result in contactQuery)
            Console.WriteLine("Last Name: {0}; First Name: {1}",
            result.LastName, result.FirstName);
    }
