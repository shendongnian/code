    class MyClass
    {
        
        private void InitializeStuff()
        {
            //do some stuff.. set _val1,_val2,_val3
        }
    
        string _val1 = null;
    
        public string Val1
        {
            get { return _val1; } 
            set 
            {
               InitializeStuff();
               _val1 = value; // Unless InitializeStuff sets this, in which case pass value in to it.
            }
        }  
    
        public MyClass()
        {
            // If needed:
            InitializeStuff();
        }
        public MyClass(string val_id1, string val_id2 = null, string val_id3 = null)
        {
            InitializeStuff();
        }
    }
