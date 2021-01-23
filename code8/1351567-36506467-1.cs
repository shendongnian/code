    public class Email
    {
         public int Id {get; set;}
         // other properties
    }
    
    public class EmailResponse
    {
         public int EmailId {get; set;}
         public int PreviousEmailId {get; set;}
    
         public virtual Email Email {get; set;}
         public virtual Email PreviousEmail {get; set;}
    }
