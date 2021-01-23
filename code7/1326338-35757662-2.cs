    public class RestrictedDate : ValidationAttribute
    {
       public override bool IsValid(object date) 
       {
           DateTime date = (DateTime)date;
           return date < DateTime.Now;
       }
    }
