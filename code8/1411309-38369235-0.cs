    using (DBEntities db = new DBEntities())
    {
        var people = db.People.ToList();
    
        // maps each keyword to a property in the Person class
        var keywordPropertyMapping = new Dictionary<string, Func<Person, string>>()
        {
            { "#Title", p => p.Title },
            { "#Name", p => p.Name },
            { "#Surname", p => p.Surname }
        };
    
        foreach (var person in people)
        {
            foreach(var keywordFunc in keywordPropertyMapping)
            {
                body = body.Replace(keywordFunc.Key, keywordFunc.Value(people));
            }
        }
    }
