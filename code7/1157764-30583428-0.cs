    class baseClass
    {
        public string Firstname;
        public string LastName;
        public string ID;
    
      public baseClass(string fn, string ln, string id)
    {
      this.Firstname = fn;
      this.LastName = ln;
      this.ID = id; 
    }
    }
    
    class TypeOneAditionalInformation: baseClass
    {
       public string x1;
       public string x2;
    
     public TypeOneAditionalInformation(string fn, string ln,
                 string id, string x1, string x2) : base(fn, ln, id)
    {
      this.x1 = x1;
      this.x2 = x2;
    }
    } 
