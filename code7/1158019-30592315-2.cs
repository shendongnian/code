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
        public void UpdateStr(string strValue)
        {
          Str = strValue;
          DoSomething();
        }
    }
