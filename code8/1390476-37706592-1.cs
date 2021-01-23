    public class Test : Model<Person>
    {
        public Person Person { get; set; }
        public Test() : base()
        {
            DataService = new PersonService();
        }
    }
