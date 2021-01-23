    public string SendUserData(string Name, string Password, string Email)
    {
        SqlCeConnection conn = new SqlCeConnection("Data Source = " + HttpContext.Current.Server.MapPath(".") + "\\App_Data\\Database_Users.sdf");
        SqlCeCommand cmd = new SqlCeCommand("INSERT INTO User (Username, Password, Email) VALUES ('" + Name + "' , '" + Password+ "' , '" + Email + "')" , conn );
        conn.Open();
        cmd.ExecuteNonQuery();
        return cmd.CommandText;
    }
