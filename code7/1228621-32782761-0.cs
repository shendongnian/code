    private void MultiRecordsInsert(TaxablePersonContext context, List<TaxablePerson> personsToAdd)
    {
      List<SqlParameter> parameters = new List<SqlParameter>();
      string firstQuery = @"insert into TaxablePerson (c1, c2, c3) values ";
      string query = firstQuery;
      for (int i = 0; i < personsToAdd.Count; i++)
      {
        query += "(@c1" + i.ToString();
        query += ",@c2" + i.ToString();
        query += ",@c3" + i.ToString() + "),";
        parameters.Add(new SqlParameter("@c1" + i.ToString(), personsToAdd[i].c1));
        parameters.Add(new SqlParameter("@c2" + i.ToString(), personsToAdd[i].c2));
        parameters.Add(new SqlParameter("@c3" + i.ToString(), personsToAdd[i].c3));
        // table has 16 columns (I reduced here for simplicity) so: 2100 / 16 = 131, 
        // used 100
        //
        if (i % 100 == 0)
        {
          query = query.Substring(0, query.Length - 1); // remove last comma
          context.Database.ExecuteSqlCommand(query, parameters.ToArray());
          query = firstQuery;
          parameters = new List<SqlParameter>();
        }
      }
      if (parameters.Count > 0) // what is left
      {
        query = query.Substring(0, query.Length - 1);
        context.Database.ExecuteSqlCommand(query, parameters.ToArray());
      }
    }
