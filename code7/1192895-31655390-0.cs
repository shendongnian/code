    public string GetFirstNameForPeron(string personId)
    {
        peopleEntities entities = new peopleEntities(); // new up your EF context
        
        return entities
            .Person // from the person entities
            .Where(w => w.ID == personId) // Where the ID = personId
            .FirstOrDefault(); // take the first available
            .Fname; // only the Fname property
    }
