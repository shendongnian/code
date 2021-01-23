    public class Person : IPerson
    {
        private readonly string _name;
        public Person()
        {
            _name = "Person";
        }
    
        public string Name
        {
            get { return _name; }
        }
    }
