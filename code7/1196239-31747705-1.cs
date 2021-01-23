    using (var db = new MyDataContext())
    {
        var newPerson = new PersonModel
        {
            Name = person.Name,
            Title = person.Title
        };
        db.Persons.Add(newPerson);
        db.SaveChanges();
    }
