    public class ClientData : IWhatsit
    {
       public string Name {get; set;}
       public string Email {get; set;}
       ...
       public string ToApiString()
       {
           // Do whatever you need here - use a string builder if you want
           return string.Format("Name={0}&Email={1}",Name,Email);
       }
    }
    
