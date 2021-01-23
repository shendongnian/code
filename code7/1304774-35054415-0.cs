    public class SurveyDbModel
    {
        // name of connection string for database that 
        private static readonly string _ConnStrName = "LocalDb";
    
        private SqlConnection Conn; 
    
        public SurveyDbModel ( )
        {
            this.Conn = new SqlConnection(ConfigurationManager.ConnectionStrings[SurveyDbModel._ConnStrName].ConnectionString);
        }
    }
