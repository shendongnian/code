    public class FirstName
    {
        string Value { get; set; }
    }
    public class MiddleName
    {
        string Value { get; set; }
    }
    public class LastName
    {
        string Value { get; set; }
    }
    
    public interface IPerson
    {
        FirstName FirstName {get;}
        MiddleName MiddleName { get; }
        LastName LastName { get;}
    }
    public class PersonNeedAllProperties : IPerson
    {
        public FirstName FirstName { get; private set;} // ideally readonly
        public MiddleName MiddleName { get; private set;}
        public LastName LastName { get; private set;}
    
        public PersonNeedAllProperties(
            FirstName firstName,
            MiddleName lastName,
            LastName middleName)
        {
            this.FirstName = firstName;
            this.MiddleName = middleName;
            this.LastName = lastName;
        }
    }
