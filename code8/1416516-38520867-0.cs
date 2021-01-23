    public class Person : IPerson
    {
        private string _name;
        public Person()
        {
            _name = "Person";
        }
    
        public string Name
        {
            get
            {
                return _name;
            }
        }
    }
