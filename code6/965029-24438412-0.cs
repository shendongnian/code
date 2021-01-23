     class myClass
        {
            //Properties
            private string privateString;
    
            //Constructor
            public myClass()
            {
    
            }
    
            //Methods
            public void setString(string val)
            {
                privateString += val;
            }
    
            public string getString()
            {
                return privateString;
            }
            
        }
