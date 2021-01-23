    public class Person
    {
        public Date BirthDate {get; set;}
        public Age { get { return BirthDate.Year - DateTime.Now.Year; } } //read only
    }
