    public IList GetPlaces()
    {
      using (var conn = new SqlConnection("blahblahblah"))
      {
        conn.Open();
        var cmd = conn.CreateCommand();
        cmd.CommandText = "SELECT p.Name, h.pointX, h.pointY FROM places p LEFT OUTER JOIN horizons h ON h.parent_key = p.Name";
        DataTable tbl = new DataTable();
        using (var rdr = cmd.ExecuteReader())
          tbl.Load(rdr);
        return tbl.Rows
          .Cast<DataRow>()
          .Select(r => new
            {
              Name = r.Field<string>("Name"),
              HorizonX = r.Field<float>("pointX"),
              HorizonY = r.Field<float>("pointY")
            }).ToList();
      }
    }
