    public static List<List<object>> loadSQL(string query, string connectString)
    {
        List<List<object>> dataList = new List<List<object>>();
    
        using (SqlConnection connection = new SqlConnection(connectString))
        {
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                connection.Open();
    
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        List<object> tempRow = new List<object>();
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            tempRow.Add(reader[i]);
                        }
                        dataList.Add(tempRow);
                    }
                }
            }          
        }
        return dataList;
    }
