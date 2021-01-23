    interface Customer
    {
       // Property signatures: 
       string Name 
       {
          get;
          set;
       }
    
       string pdw 
       {
          get;
          set;
       }
    }
    
    class Login : Customer
    {
       // Fields: 
       private string _name;
       private string _pdw;
    
       // Constructor: 
       public Login ()
       {
    
       }
    
       // Property implementation: 
       public string name
       {
          get
          {
             return _name;
          }
    
          set
          {
             _name = value;
          }
       }
    
       public string pdw
       {
          get
          {
             return _pdw;
          }
          set
          {
             _pdw = value;
          }
       }
    }
