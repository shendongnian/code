    public class SqlHelper
    {
       public SqlHelper(string connString)
       {
          
       }
       
       public DataSet GetDatasetByCommand(string Command);
       public SqlDataReader GetReaderBySQL(string strSQL);
       public SqlDataReader GetReaderByCmd(string Command);
       public SqlConnection GetSqlConnection();
       public void CloseConnection(); 
    
    }
