    public class ClientData : BaseData
    {
       public string Name {get; set;}
       public string Email {get; set;}
       ...
    
       protected override string ToApiString()
       {
           // Do whatever you need here - use a string builder if you want
           return string.Format("Name={0}&Email={1}",Name,Email);
       }
    }
