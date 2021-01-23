    using System.Data.SqlClient;
    
    public class Sqlconnect 
    {
        public SqlConnection Con { get; set; }//the object
        private string conString { get; set; }//the string to store your connection parameters
    }
