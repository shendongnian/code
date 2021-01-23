    class Group
    {
        //Fields
        private string nameGroup;
        
        //Properties
        public string NameGroup
        {
            get; //There is nothing in the property, and it is never used either!
            set;
        }
    
        //Constructor
        public Group(string name)
        {
            this.nameGroup = name; //this means the field is updated    
        }
     }
