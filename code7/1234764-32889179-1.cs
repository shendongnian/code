    private void Test2(SqlConnection con)
    {
        var userIDs = new List<String>();
        using (var cmd = new SqlCommand("select UserId from WT_Users", con))
        {
            con.Open();
            using (var r = cmd.ExecuteReader())
            {
                while (r.Read())
                {
                    var o = r[0];
                    if ((o != null) && (o != DBNull.Value))
                    {
                        userIDs.Add(o.ToString());
                    }
                }
            }
        }
    }
