    protected bool checkDB()
    {
      var connString = @"Server=myServerName\myInstanceName;Database=myDataBase;User Id=myUsername;Password = myPassword;";
      try
      {
        using (var con = new SqlConnection(connString))
        {
          con.Open();
          using (var com = new SqlCommand("SELECT * FROM tableName", con))
          {
            // use your query here...
          }
        }
        return true;
      }
      catch (Exception)
      {
        return false;
      }
    }
