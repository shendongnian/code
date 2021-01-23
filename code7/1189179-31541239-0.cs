    private void button1_Click(object sender, EventArgs e)
    {
        MessageBox.Show("DOING STUFF");
            string connectionString = @"Data Source=.\wintouch;Initial Catalog=bbl;User ID=sa;Password=Pa$$w0rd";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string queryString = "DELETE FROM wgcdoccab WHERE serie ='1' tipodoc ='FSS' AND and contribuinte ='999999990' and  datadoc = CONVERT(varchar(10),(dateadd(dd, -2, getdate())),120) ";                    
                SqlCommand command = new SqlCommand(queryString, connection);
                command.ExecuteNonQuery();
            }
    }
