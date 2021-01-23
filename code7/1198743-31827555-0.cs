     using (SqlCommand sqlCommand = new SqlCommand(querry, conn))
    {
            SqlDataReader reader;
            int id = -1;
    
            using (reader = sqlCommand.ExecuteReader())
            {
    
                if (reader.Read())
                {
    
    
                    String data= reader["sdata"].ToString();
                    Order o = new Order(reader["sdata"].ToString());
                    o.prepareForScript();
                    id = reader.GetSqlInt32(1).Value;
                }
                reader.Close();
            }
    }
