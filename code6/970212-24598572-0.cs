    using(OleDbConnection conn = new OleDbConnection(a correct connection string here))
    using(OleDbCommand cmd = new OleDbCommand(@"select * from Employee 
                                                where username = ? AND [Password] = ?", conn);
    {
         
        conn.Open();
        cmd.Parameters.AddWithValue("@p1", this.tbUsername.Text);
        cmd.Parameters.AddWithValue("@p2", this.tbPassword.Text);
        using(OleDbDataReader dr = cmd.ExecuteReader())
        {
           .....
        }
    }
