    string sql = "SELECT DISTINCT UID = STUFF( "
                + "( "
                + "SELECT ';' + UID FROM USERS WHERE [urole] = 'support' "
                + "FOR XML PATH  ('')), 1, 1, '' "
                + ") "
                + "FROM USERS AS t";
    SqlConnection conn = new SqlConnection(connectionString);
    conn.Open();
    SqlCommand cmd = new SqlCommand(sql, conn);
    SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
    if (dr.HasRows)
    {
        while (dr.Read())
        {
            // process data
        }
    }
