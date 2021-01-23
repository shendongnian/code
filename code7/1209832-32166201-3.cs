     string connStr = @"Data Source=ANLZ\SQLEXPRESS;Initial Catalog=testdb; Trusted_Connection=True;";
        int updateId = int.Parse(formTextBox.Text); //Or where ever you set the ID to when it is pulled from the database.
        string deleteComand = "Delete FROM tbl_test WHERE ID = @id"; 
        using (OleDbConnection conn = new OleDbConnection(connStr))
        {
            using (OleDbCommand comm = new OleDbCommand())
            {
                comm.Connection = conn;
                comm.Parameters.AddWithValue("@id",updateId);
                try
                {
                    comm.Open();
                    conn.ExecuteNonQuery();
                }
                catch(OleDbException ex)
                {
                    //Do some error catching Messagebox/Email/Database entry 'Or Nothing'
                }
            }
        }
