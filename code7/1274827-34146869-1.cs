    private static OleDbConnection GetConnection()
    {
        var connString = @"Provider=Microsoft.JET.OLEDB.4.0;Data Source=C:\Users\Wisal\Documents\Visual Studio 2012\WebSites\WebSite3\registration-Db.mdb";
    
        return new OleDbConnection(connString);
    }
    
    protected void clientUpdate_Click(object sender, EventArgs e)
    {
        using(var myConnection = GetConnection())
        {
            myConnection.Open();
            // You should be using a parameterized query here
            using (var cmd = new OleDbCommand("Update client set [name] = ?, [password] = ? where id = ?", myConnection))
            {
                cmd.Parameters.AddWithValue("name", txt_name.Text);
                cmd.Parameters.AddWithValue("password", txt_password.Text);
                cmd.Parameters.AddWithValue("id", txt_id.Text);
                cmd.ExecuteNonQuery();
            }
        }
    }
