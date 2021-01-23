    public class StaticContext
    {
        public static SqlConnection getConnessione()
        {
            string conn = string.Empty;
            conn = System.Configuration.ConfigurationManager.ConnectionStrings["connectionStringName"].ConnectionString;
            SqlConnection aConnection = new SqlConnection(conn);
            return aConnection;
        }
    }
