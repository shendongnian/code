    public int runNonQuery(string query)
    {
        try
        {
            if (connectionDB())
            {
                OleDbCommand sqlQuery = new OleDbCommand(query, _OleDBconnection);
                int rows = sqlQuery.ExecuteNonQuery();
                disconnectDB();
                return rows;
            }
        }
        catch(Exception ex)
        {
            System.Windows.Forms.MessageBox.Show(ex.Message);
            return -1;
        }
    }
