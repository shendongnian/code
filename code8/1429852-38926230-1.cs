    interface IPerson
    {
        string Name { set; }
    }
    
    class Person : IPerson
    {
        private string _name;
        public String Name
        {
            set { _name = value; }
        }
    }
