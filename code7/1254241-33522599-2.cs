    public class MyModelEntities : DbContext
    {
       public MyModelEntities()
       {
          //just disable it like this  
          Configuration.ProxyCreationEnabled = false;
       }
    }
