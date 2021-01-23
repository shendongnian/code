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
            using (var cmd = new OleDbCommand("Update client set [name] = '" + txt_name.Text + "', [password] = '" + txt_password.Text + "' where id=" + txt_id.Text, myConnection))
            {
                cmd.ExecuteNonQuery();
            }
        }
    }
