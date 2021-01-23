    ....
    var terminalList = new List<Terminals>();
    while (reader.Read())
    {
        Terminals t = new Terminals();
        int pos = reader.GetOrdinal("id");
        if(pos != -1) t.Id = reader.GetInt32(pos);
        pos = reader.GetOrdinal("Name");
        if(pos != -1) t.Name = reader.GetString(pos);
        pos = reader.GetOrdinal("Type");
        if(pos != -1) t.Type = reader.GetString(pos);
        pos = reader.GetOrdinal("Hacked");
        if(pos != -1) t.Hacked = reader.GetBoolean(pos);
        terminalList.Add(t);
    }  
    ....
