    using (SqlDataReader reader = command.ExecuteReader())
    {
        if (reader.Read())
        {
            var dto = new GetTestsDTO();
            dto.Current = Convert.ToBoolean(reader.GetInt32(1));
        }
    }
