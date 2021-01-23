    public List<Station> GetStations()
    {
      using (Context context = new Context())
        return context.Stations
          .ToList();
    }
    public List<Record> GetRecords()
    {
      using (Context context = new Context())
        return context.Records
          .Include(record => record.Station)
          .ToList();
    }
