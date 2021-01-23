    public enum PersonType
    {
        Teacher,
        Student    
    }
    public class Person
    { 
        public PersonType PersonType {get;set;}
    }
    public class Teacher : Person
    {
        public Teacher()
        {
            PersonType = PersonType.Teacher;
        }
    }
