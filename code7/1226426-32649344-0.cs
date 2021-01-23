    while (reader.Read()) 
    {
    if (!reader.IsDBNull(reader.GetOrdinal("Image_ID1")))
     i.Add(reader.GetInt32(reader.GetOrdinal("Image_ID1")));
    
    if (!reader.IsDBNull(reader.GetOrdinal("Image_ID2")))
     i.Add(reader.GetInt32(reader.GetOrdinal("Image_ID2")));
    
    }
