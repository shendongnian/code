    private void insertBtn_Click(object sender, EventArgs e)
    {
        // Open your connection
        using(var myConnection = new SqlCeConnection(@"Data Source=C:\Users\Saeed\Documents\Visual Studio 2012\Projects\dictionary1\dictionary1\Database1.sdf;Persist Security Info=False;"))
        {
             // Build your query
             var query = "INSERT INTO dictionary (id,enWord,faWord) VALUES (4,'pen','خودكار')"
             // Build a command to execute
             using(var myCommand = new SqlCeCommand(query,myConnection))
             {
                   // Open your connection
                   myConnection.Open();
                   // Execute your query
                   myCommand.ExecuteNonQuery();
             }
        }
    }
