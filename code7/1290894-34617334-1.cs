    public class PersonRepository : IRepository<Person> {
        private OrtundEntities db = new OrtundEntities();
    
        public IEnumerable<Person> Get() {
            return db.Persons.ToList();
        }
        
        //invoke the rest of the interface's methods
        (...)
    }
