    namespace RSS_Aankondigingen
 
    public class DatbaseHelper
    {
    public DataSet GetDataSet(string selectOn)
    {
            sqlConn.Open();
        
    string sqlQuery = string.format("SELECT ID, Title,  CONCAT(CONVERT(char(16), Date, 103),CONVERT(char(5), Date, 108)) AS Date, Recurrent FROM tblAnnouncements WHERE Channel = '{0}' ORDER BY Date", selectOn);
 
            SqlCommand sqlCmd = new SqlCommand(sqlQuery, sqlConn);
            SqlDataAdapter sqlDA = new SqlDataAdapter(sqlCmd);
            DataSet ds = new DataSet();
            sqlDA.Fill(ds);
            sqlConn.Close();
            return ds;
    }
    }
