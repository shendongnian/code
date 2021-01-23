    public class Person
    {
        public Date BirthDate {get; set;}
        public int Age { get { return (DateTime.Now.Year - BirthDate.Year); } } //read only
    }
