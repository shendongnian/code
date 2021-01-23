    string variablestr;
    
    if (!reader.IsDBNull(reader.GetOrdinal("table-of-int")))
    {
       variablestr = Convert.ToString(reader.GetInt32(reader.GetOrdinal("table-of-int"))).PadRight(32);
    
    }
    else
    {
        variablestr = new string(' ', 32);
    };
