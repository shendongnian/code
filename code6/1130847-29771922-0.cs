    public bool IsSelOne {get; set;}
    public bool IsSelTwo {get; set;}
    public boolean Selection { 
       get { 
           // case IsSelOne == IsSelTwo is an invalid state
           // it's up to you to handle that
           return IsSelOne ; 
       } 
       set {
           IsSelOne = value;  
           IsSelTwo = !value ; 
       } 
    }
