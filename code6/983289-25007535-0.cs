    public PrivelegeCeck Login(string username, string password) {
    {
            NpgsqlCommand cmd = new NpgsqlCommand("select * from \"Users\" where \"UserName\" = :username and \"Password\" = :password;", conn);
            cmd.Parameters.Add(new NpgsqlParameter("username", username));
            cmd.Parameters.Add(new NpgsqlParameter("password", password));
        ...
        ...
        PrivelegeCheck check;
        int privelegeLevel = 0;
        if(reader.Read()) {
           check = new PrivelegeCheck();
           // We try parsing the reader ordinal by passing in the field name reference
           if(int.TryParse(r["<field_name_here>"].ToString(), out privelegeLevel))
              check.PrivelegeLevel = privelegeLevel;
        }
        return check;
    }
