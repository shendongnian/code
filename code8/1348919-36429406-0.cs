    using(EntityContext db = new EntityContext())
    {
         db.LazyLoadingEnabled = true;
         List<Persons> persons = db.Persons.ToList();
    }
