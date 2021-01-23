    using (MySqlConnection lconn = new MySqlConnection(connString))
    {
        lconn.Open();
        using (MySqlCommand cmd = new MySqlCommand())
        {
            cmd.Connection = lconn;
            cmd.CommandText = "update " + activeTblName + " set bn=@bn where qId=@qId";
            cmd.Prepare();
            cmd.Parameters.AddWithValue("@qId", pqId);
            cmd.Parameters.AddWithValue("@bn", ptheValue);
            cmd.ExecuteNonQuery();
        }
    }
