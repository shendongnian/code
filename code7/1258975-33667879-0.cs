    SqlDataReader dr= command.ExecuteReader();
    
            while (dr.HasRows)
            {
    
                while (dr.Read())
                {
                    colna.Add(dr.GetString(1)) // name as string
                    colpr.Add(dr.GetInt32(2)) // price is integer
                    colpr.Add(Convert.ToDecimal(dr(2)))// if decimal
                    colpr.Add((float)(dr(2))// if Float
                    OR
                    colna.Add(dr["Name"].ToString()); 
                    colpr.Add((float)dr["Price"]);
                    .... 
                }
                reader.NextResult();
            }
