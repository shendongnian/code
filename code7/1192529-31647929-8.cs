    int CountReferrers(string accountID, string position = null)
    {
      int count = 0;
      // If a position argument was specified, add the filter to the query
      string cmdText = "SELECT * FROM Accounts WHERE AssignedTo=@Referrer";
      if (position != null)
        cmdText += " AND PyramidPosition=@Position";
      var cmd = new SqlCommand(cmdText, this.Connection);
      cmd.Parameters.AddWithValue("@Referrer", accountID);
      // If a position argument was specified, add the value to the parameter
      if (position != null)
        cmd.Parameters.AddWithValue("@Position", position);
      // Count the child referrers, without specifying position
      using (SqlDataReader reader = cmd.ExecuteReader())
      {
        while (reader.Read())
          count += CountReferrers(reader["AccountID"].ToString());
      }
      return count;
    }
    void Main()
    {
      string userId = Session["UserID"].ToString();
      int referrerCount = CountReferrers(userId, "Left");
      Console.Write(referrerCount);
    }
