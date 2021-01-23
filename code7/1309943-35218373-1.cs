    UtilityCase uc=new UtilityCase((col) =>
    {
        //I want to be able to Set this from outside of the UtilityCase
        var context = new Context();
        //I want to remove the referance to the Entity (DB) Person
        foreach (EntityObject item in col)
        {
            //add person to db
            context.Persons.Add((Person)item));
        }
        context.SaveChanges();
    });
