    public static IEnumerable<IDataReader> Reader(string query, object[,] parameters)
    {
        using(SqlConnection cn = new SqlConnection(.....))
        using(SqlCommand com = new SqlCommand(query, cn))
        {
            for (int i = 0; i < parameters.Length/2; i++)
                com.Parameters.AddWithValue(parameters[i, 0].ToString(), parameters[i, 1]);
            cn.Open();
            using(SqlDataReader r = com.ExecuteReader())
            {
                while(r.Read())
                    yield return r;
            }
        }
    }
