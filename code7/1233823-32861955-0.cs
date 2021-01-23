    if (reader.HasRows)
    {
        StringBuilder commaList = new StringBuilder();
        while (reader.Read())
        {
            commaList.Append(reader["Att"].ToString());                                                                      
            commaList.Append(",");
        }
        commaList.Remove(commaList.Lenth-1,1);
        Response.Write(commaList.ToString());
    }
