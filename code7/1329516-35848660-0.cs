    public class BaseClass
    {
       public virtual string GetStatus
       {
           get{
               return "Ok";
           }
       }
    }
    public class AClass():BaseClass
    {
       public bool someMethod()
       {
           return GetStatus == "Ok";
       }
    }
