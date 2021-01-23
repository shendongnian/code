    using (var transaction = new System.Transactions.TransactionScope())
    {
      using (var connection = new MySqlConnection())
      {
         ...
      }
    }
