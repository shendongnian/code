    public class EspEntities : DbContext
    {
       public EspEntities()
       {
          Configuration.ProxyCreationEnabled = false;
       }
    }
