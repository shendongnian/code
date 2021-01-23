    private string EmpPassword(string sqlText, System.Data.SqlClient.SqlConnection openConnection)
    {
        object obj = null;
        using (var cmd = new System.Data.SqlClient.SqlCommand(sqlText, openConnection))
        {
            using (var r = cmd.ExecuteReader())
            {
                if (r.Read())
                {
                    obj = r.GetValue(0);
                }
            }
        }
        if ((obj != null) && (obj != DBNull.Value))
        {
            return obj.ToString().Replace(" ", "");
        }
        return null;
    }
