    foreach (string str in arr2)
    {
        command1.Parameters["@groupID"].Value = str;
        using(SqlDataReader reader = command1.ExecuteReader())
        {
            while (reader.Read())
            {
                userID.Add(reader["ID"].ToString());
            }
        }
    }
