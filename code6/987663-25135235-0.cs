    class Person
    {
        private string name = "N/A";
    
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = "My name is:" + value;
            }
        }
    }
