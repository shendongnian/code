    public enum WinnerKind {
      Winner = 0,
      Double = 1
    }
   ...
    
    public static List<string> GetWinnersData(Prize prize, WinnerKind kind) {
      List<string> result = new List<string>();
    
      // You don't have to concat strings
      // it's a good practice to use parametrized queries: "PrizeID = ?" 
      String query = String.Format(
        @"SELECT Member.IBAN,
            FROM Member, 
                 Summary,
           WHERE Member.ID = {0}
             AND PrizeID = ?",
        kind == WinnerKind.Winner ? "Summary.WinnerID" : "Summary.DoubleID");
    
      using (OleDbConnection connection = new OleDbConnection(ConfigurationManager.ConnectionStrings["ForteLotteryDataConnectionString"].ConnectionString)) {
        connection.Open();
    
        using (OleDbCommand command = new OleDbCommand(query, connection)) {
          // named parameters aren't supported
          command.Parameters.Add(prize.ID);
    
          using (OleDbDataReader reader = command.ExecuteReader()) {
            while (reader.Read()) 
              result.Add(Convert.ToString(reader[0].GetValue()));
          }
        } 
      }
      return result;  
    }
    public static List<string> GetWinners(Prize prize) {
      return GetWinnersData(prize, WinnerKind.Winner);
    }
    public static List<string> GetDoubles(Prize prize) {
      return GetWinnersData(prize, WinnerKind.Double);
    }
