    if (property.Name == "Person")
    {
        // This is a Person PropertyInfo.
        
        Person person = value as Person;
        if (person == null)
        {
           // This is not expected. Log and return
        }
    
        //Now you can access person.Name
    }
