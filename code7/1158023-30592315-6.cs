    Class A
    {
         //field
        private string _str;
        
        // member
        public string Str
        {
          get { return _str; }
          private set { _str = value; }
        }
        private void DoSomething()
        {
           ..
           ..
        }
        public void UpdateStrAndDoSomething(string strValue)
        {
          Str = strValue;
          DoSomething();
        }
    }
