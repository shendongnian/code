    public class MyContext : DbContext{
    
      MyContext(){
            Database.Log = Console.WriteLine;
            //or like this 
            //Database.Log = message => Trace.TraceInformation(message);
      }
    }
       
     
