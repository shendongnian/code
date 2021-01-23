    public ArrayList Execute(string req)
    {
    ArrayList output = new ArrayList();
    [...]
    
    cmd = new OdbcCommand(req);
    cmd.Connection = accessConnection;
    
    OdbcDataReader reader = cmd.ExecuteReader();
    while (reader.Read()) {
        String[] row = new String[reader.FieldCount];
    
        for (int i=0; i<reader.FieldCount; i++) {
            if (!reader.IsDBNull(i)) { // Added if for Visual Studio
                if (i > 0 && i < 2)
                {
                    row[i] = reader.GetInt32(i);
                }
                else
                {
                    row[i] = reader.GetString(i);
                }
            }
        }
    
        output.Add( row );
    }
    
    [...]
    return output;
    }
