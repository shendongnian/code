    public bool IsSelOne {get; set;}
    public bool IsSelTwo {get; set;}
    public bool Selection { 
       get { 
           return IsSelOne ; 
       } 
       set {
           IsSelOne = value;  
           IsSelTwo = !value ; 
       } 
    }
