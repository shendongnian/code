    public static int SSN_DB(IWebDriver session, string connString) {
      //creating a db connection connection
      var DBConnection = new SqlConnection(connString);
      DBConnection.Open();
      // Can execute a query or store procedure 
      var MemTable = new SqlCommand();
      MemTable.CommandText = "Select top 1 SSN from dbo.member order by EMPL desc";
      MemTable.Connection = DBConnection;
      var dr = MemTable.ExecuteReader();
      var Memberid = 0;
    
      while (dr.Read()) {
        Memberid = dr.GetInt32(0);
        Console.WriteLine(Memberid);
      }
      return Memberid;
    }
    
    }
