    private void btnSave_Click(object sender, RoutedEventArgs e)
    {
        using (OleDbConnection DBConnect = new OleDbConnection())
        {
            DBConnect.ConnectionString = @"Provider=Mi...";
            DBConnect.Open();
            OleDbCommand com = new OleDbCommand("INSERT INTO ...", DBConnect);
           
            // Parameters goes here
           
            if (DBConnect.State == ConnectionState.Open)
            {
                com.ExecuteNonQuery();
            }
            
            //...
            // No need to close connection
        }
    }
