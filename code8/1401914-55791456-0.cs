    public int GetNumberOfRecordsFromTable()
    {
      return session.QueryOver<YourTable>()
                .Select(Projections.RowCount())
                .FutureValue<int>()
                .Value;
    }
