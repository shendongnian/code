    string city="";
    string state= "";
    NpgsqlCommand cmd = new NpgsqlCommand("select city,state from streams limit 5", conn);    
    
    var citiesString = string.Empty;
    using (var reader = cmd.ExecuteReader())
    {
        while (reader.Read())
        {
            city = reader.GetString(reader.GetOrdinal("city"));
            state = reader.GetString(reader.GetOrdinal("state"));
            citiesString += city + ", ";
        }
    }
    return Json(citiesString.TrimEnd(new []{' ', ','}));
