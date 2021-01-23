    // C# class
    public class clsDataLayer
    {
        // This functions insert data into tblPersonnel table
        public static bool SavePersonnel(string Database, string FirstName, string LastName, string PayRate, string StartDate, string EndDate)
        {
            bool recordSaved;
            try
            {
               OleDbConnection conn = new OleDbConnection("PROVIDER=Microsoft.ACE.OLEDB.12.0;" + "Data Source=" + Database);
               conn.Open();
               OleDbCommand command = conn.CreateCommand();
               string strSQL;
               // Add your comments here
               strSQL = "Insert into tblPersonnel " +
               "(FirstName, LastName, PayRate, StartDate, EndDate) values ('" + FirstName + "', '" + LastName + "', " + PayRate + ", '" + StartDate +  "', '" + EndDate + "')";
               // Add your comments here
               command.CommandType = CommandType.Text;
               command.CommandText = strSQL;
               // Add your comments here
               command.ExecuteNonQuery();
               // Add your comments here
               conn.Close();
               recordSaved = true;
            }
            catch (Exception ex)
            {
                recordSaved = false;
            }
            return recordSaved;     
        }
        // This function retrieves all data from tblPersonnel table
        public static dsPersonnel GetPersonnel (string Database, string strSearch)
        {
            dsPersonnel DS;
            OleDbConnection SqlConn;
            OleDbAdapter sqlDA;
            //Opens OleDbConnection
            sqlConn = new OleDBConnection("PROVIDER=Microsoft.ACE.OLEDB.12.0;" + "Data Source=" + Database);
            //Employee Search (procured from video, add in later?
            if (strSearch == null || strSearch == "")
            {
                sqlDA = new OleDbDataAdapter("Select * from tblPersonnel", sqlConn);
            }
            else
            {
                 sqlDA = new OleDbAdapter("Select '' from tblPersonnel where LastName = '" + strSearch + "'", sqlConn);
            }
            //Sets Value of DS
            DS = new dsPersonnel();
            //Fills Table with Data
            sqlDA_Fill(DS.tblPersonnel);
            //Return value
             return DS;
         }
         //End Function: Public static dsPersonnel GetPersonnel
    }
