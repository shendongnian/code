    public static List<List<string>> loadSQL(String query, String connectString)
        {
            List<List<string>> dataList = new List<List<string>>();
    
            using (SqlConnection connection = new SqlConnection(connectString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
    
                {
                    connection.Open();
    
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var l = new List<string>();
                            for (int i = 0; i < reader.FieldCount; i ++) 
                                { 
                                    l.Add(Convert.ToString(reader.GetValue(i)));
                                }
                            dataList.Add(l);
                        }
                    }
                }
            return dataList;
    
            }
        }
