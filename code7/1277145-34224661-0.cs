    using (SqlConnection conn = new SqlConnection("Data Source=.; Initial Catalog=DBNAME; Integrated Security=true;"))
    {
        conn.Open();
        using (SqlCommand cmd = new SqlCommand("SELECT ID, NAME FROM VIEWNAME where id > 4550;", conn))
        {
            // cmd.CommandType = CommandType.StoredProcedure // for SP
            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    dictionary.Add(dr.GetInt32(0), dr.GetString(1));
                }
            }
        }
    }
