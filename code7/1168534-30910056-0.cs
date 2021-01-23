    internal static DataSet executeQuery(string queryString)
    {
        DataSet dataSet = new DataSet();
        string connectionString = Connection.connectionStringSQL01NavProvider();
        using (var connection = new OleDbConnection(connectionString))
        using(var adapter = new OleDbDataAdapter(queryString, connectionString))
        {
            try
            {
                adapter.Fill(dataSet); // you dont need to open/close the connection with Fill
            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                System.Windows.Forms.MessageBox.Show("Error executeQuery().! " + ex.Message);
            }
        }
        return dataSet;
    }
