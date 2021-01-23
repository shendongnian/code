    public static List<string[]> loadSQL(String query, String connectString)
    {
    List<string[]> dataList = new List<string[]>();
    using (SqlConnection connection = new SqlConnection(connectString))
    {
        using (SqlCommand command = new SqlCommand(query, connection))
        {
            connection.Open();
            using (SqlDataReader reader = command.ExecuteReader())
            {
                int rowcounter = 0;
                while (reader.Read())
                {
                    string[] value = new string[reader.FieldCount];
                    for (int i = 0; i < reader.FieldCount; i ++) 
                        { 
                            value[i] = Convert.ToString(reader.GetValue(i));
                        }
                    dataList.Add(value);
                    rowcounter++;
                }
            }
        }
    return dataList;
    }
