    protected static bool Authentication(string usernames, string passwords)
    {
        string sqlcmd = "SELECT UName, Pwd from  [SignupDB] where UName = '" + usernames + "' and Pwd = '" + passwords + "'";
    
        using(OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|/DB1.mdb;Persist Security Info=True;Jet OLEDB:Database Password=mypassword"))
        {
          con.Open();
          OleDbCommand cmd = new OleDbCommand(sqlcmd, con);
          using(OleDbDataReader reader = cmd.ExecuteReader())
          {
            if (reader.Read())
                return true;
            else
                return false;
    
          }
        }    
    }
