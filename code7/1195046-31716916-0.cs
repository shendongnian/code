    var timeSeries = new List<ListOfClass>();  
    using (var reader = cmd.ExecuteReader())
    {
       if (reader.HasRows)
      {
          timeSeries = reader.Cast<IDataRecord>()
               .Select(r => new ListOfClass
                 {
                     fname = (string)r["fname"],
                                iduser = (string)r["iduser"]
                 }).ToList();
      }
    }
