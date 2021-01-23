    public static List<object[]> loadSQL(string query, string connectString)
    {
        List<object[]> dataList = new List<object[]>();
    
        using (SqlConnection connection = new SqlConnection(connectString))
        {
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                connection.Open();
    
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        object[] tempRow = new object[reader.FieldCount];
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            tempRow[i] = reader[i];
                        }
                        dataList.Add(tempRow);
                    }
                }
            }
        }
        return dataList;
    }
