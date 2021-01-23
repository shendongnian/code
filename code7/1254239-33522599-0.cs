    public class MyModelEntities : DbContext
    {
       public LabEntities()
       {
          //just disable it like this  
          Configuration.ProxyCreationEnabled = false;
       }
    }
