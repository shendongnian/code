    using (SQLiteConnection conn = new SQLiteConnection(connectionString))
    {
      conn.Open();
      using SQLiteTransaction dbTransaction = conn.BeginTransaction())
      {
        if (StockIsAvailable())
        {
          DecreaseStock();
          IncreaseCashBalance();
        }
        dbTransaction.Commit();
      }
    }
