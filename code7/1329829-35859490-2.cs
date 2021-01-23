    public class Connections
    {
        public static SqlConnection Init(string Name)
        {
            return new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings[Name].ConnectionString);
        }
    }  
