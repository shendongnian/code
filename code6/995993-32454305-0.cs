    using (MySqlCommand myCmdNested = new MySqlCommand(cCommand, mConnection))
    {
        foreach (string Code in item.Codes)
        {
            myCmdNested.Parameters.Add(new MySqlParameter("@UserID", UID));
            myCmdNested.Parameters.Add(new MySqlParameter("@Code", Code));
            myCmdNested.ExecuteNonQuery();
        }
    }
