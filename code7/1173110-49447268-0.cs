    public class PersonService : IEntityService<Person, int>
    {
       int _id;
       ...
    }
    
    public class LogService : IEntityService<Log, string>
    {
       string _id;        
       ...
    }
