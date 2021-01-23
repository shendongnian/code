    public class fnCommon
    {
        private readonly AppContext db;
    
        public fnCommon(AppContext context)
        {
            this.db = context;
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
