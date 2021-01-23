    string json = string.Empty;
    List<object> objects = new List<object>();
    using (SqlConnection conn = new SqlConnection("connectionstring"))
    {
        conn.Open();
        using (SqlCommand command = conn.CreateCommand())
        {
            command.CommandText = "SELECT * FROM USERS";
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    IDictionary<string, object> record = new Dictionary<string, object>();
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        record.Add(reader.GetName(i), reader[i]);
                    }
                    objects.Add(record);
                }
            }
        }
    }
    json = JsonConvert.SerializeObject(objects);
    using (StreamWriter sw = new StreamWriter(File.Create("C:\\path\\file.json")))
    {
        sw.Write(json);
    }
}
