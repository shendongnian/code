    public class DALManagerFactory : IDALManagerFactory
    {
        public IDALManager Create(string environment)
        {
             if(environment == "DEV")
                 return new MyDalManager(
                     ConfigurationManager.ConnectionStrings["Database"].ToString());
             //...
        }
    }
