    string SQL = @"SET @rank=0; 
                   SELECT Name, HP, StartDate, @rank:=@rank+1 As Rank 
                   FROM Demo ORDER BY HP DESC;";
    using (MySqlConnection dbcon = mySqlDB.GetMySQLConnection())
    using (MySqlCommand cmd = new MySqlCommand(SQL,dbcon))
    {
        dbcon.Open();
        DataTable dt = new DataTable();
        dt.Load(cmd.ExecuteReader());
        dgv1.DataSource = dt;
    }
