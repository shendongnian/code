    public class AppSession
    {
       public void Clear()
       {
          //Remove items from the AppSession class
          //Update AppSession instance in HTTP Context session
          HttpContext.Current.Session["__AppSession__"] = this;
       }
