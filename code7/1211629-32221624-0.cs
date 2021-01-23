    private void button1_Click(object sender, EventArgs e)
    {
        using (SQLiteConnection con = new SQLiteConnection(connectionString))
        {
            try
            {
                string createTableQuery = @"CREATE TABLE User (userName NOTNULL varchar(40), passWord NOTNULL varchar(40))";
                SQLiteCommand cmd = new SQLiteCommand();
                cmd.CommandText = createTableQuery;
                cmd.ExecuteNonQuery();//Here
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }  
        }
    }
