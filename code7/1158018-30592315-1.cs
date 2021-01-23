    Class A
    {
         //field
        private string _str;
        
        // member
        public string Str
        {
          get { return _str; }
          set { _str = value; DoSomething(); }
        }
        public void SomeMethod()
        {
           _str = "Dont access like this";
           Str= "Should access only like this";
        }
    }
