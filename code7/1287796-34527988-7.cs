    class Group
    {
        //Fields
        private string nameGroup;
        
        //Properties
        public string NameGroup
        {
            get {return nameGroup;} //this way, your nameGroup and NameGroup are one
            set {nameGroup = value;}
        }
    
        //Constructor
        public Group(string name)
        {
            this.nameGroup = name; //this means the field is updated    
        }
     }
