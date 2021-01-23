    public static MySqlCommand User(MySqlConnection MySQL, UserSearchCriteria u)
    {
        var cmdVars = new List<string>();
        const string cmd = "SELECT * FROM `schema`.`table` WHERE 1=1 AND ";
    
        var MySqlCmd = new MySqlCommand("", MySQL);
    
        if (u.ID != null) 
        {
            cmdVars.Add("`ID` LIKE @0");
            MySqlCmd.Parameters.AddWithValue("@0", u.ID);
        }
        if (u.Username != null)
        { 
            cmdVars.Add("`Username` LIKE @1");
            MySqlCmd.Parameters.AddWithValue("@1", u.Username);
        }
    
        // and the rest of the relevant properties
    
        MySqlCmd.CommandText = cmd + string.Join(" AND ", cmdVars);
    
        return MySqlCmd;
    }
    
    public void somefunction()
    {
        var myCmd = User(someconnections, new UserSearchCriteria() {FirstName = "Joe"});
    }
