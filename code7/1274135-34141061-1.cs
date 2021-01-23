    namespace DataLibrary
    {
        class PersonHelper
        {
            private readonly AppContext db;
            public PersonHelper(AppContext context)
            {
                db = context;
            }
            public int InsertPerson(tbl_Person person)
            {
                try
                {
                    db.tbl_Person.Add(person);
                    db.SaveChanges();
                    return person.PersonID;
                }
                catch
                {
                    return 0;
                }
            }
        }
    }
