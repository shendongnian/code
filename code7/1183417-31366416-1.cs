    public class Person{
        public String Name{get; set;}
        public String Email {get; set;}
        public virtual Employer employer {get; set;}
    }
    public List<EF.Person> GetPerson(){
        using(EF.DbEntities db = new EF.DbEntities()){
           return db.Person.ToList();
        }
    }
