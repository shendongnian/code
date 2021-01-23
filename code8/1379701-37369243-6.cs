    string city="";
    string state= "";
    NpgsqlCommand cmd = new NpgsqlCommand("select city,state from streams limit 5", conn);
    
    var cities = new string[5]();
    using (var reader = cmd.ExecuteReader())
    {
        while (reader.Read())
        {
            city = reader.GetString(reader.GetOrdinal("city"));
            state = reader.GetString(reader.GetOrdinal("state"));
        }
    }
    return Json(cities);
