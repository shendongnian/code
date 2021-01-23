    public class Email
    {
         public int Id {get; set;}
         public int? PrevousEmailId {get; set;}
         // other properties
    
         public virtual Email PreviousEmail{get;set;}
    }
