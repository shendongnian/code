    Dictionary<string, string> myUpdates = new Dictionary<string, string>();
    myUpdates.Add("name1", "value1");
    myUpdates.Add("name2", "value2");
    myUpdates.Add("name3", "value3");
    myUpdates.Add("name4", "value4");
    using (SqlConnection connection = new SqlConnection(connectionString))
    {
        SqlCommand command = new SqlCommand("UPDATE Table1 set value = @value where name = @name", connection);
        var nameParam = new SqlParameter("name", System.Data.SqlDbType.NVarChar);
        var valueParam = new SqlParameter("value", System.Data.SqlDbType.NVarChar);
        command.Parameters.Add(nameParam);
        command.Parameters.Add(valueParam);
        connection.Open();
        foreach (var item in myUpdates)
        {
            try
            {
                nameParam.Value = item.Key;
                valueParam.Value = item.Value;
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
