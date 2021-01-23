    public class Connections
    {   
        private SqlConnection Connection {get; set;}    
        public static void Init(string Name)
        {         
            Connection =GetInstance(Name);
        }  
             
        private SqlConnection GetInstance(string Name)
        {
            return  new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings[Name].ConnectionString);
        }
    }
