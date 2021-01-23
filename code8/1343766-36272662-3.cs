    ResultsStruct _ResultSet = new ResultsStruct();
    using (SqlConnection _Connection = new SqlConnection("Context Connection = true"))
    {
      using (SqlCommand _Command = _Connection.CreateCommand())
      {
        _Command.CommandText = "SELECT Column1, Column2 FROM #ValuesToPassIn;";
        _Connection.Open();
        using (SqlDataReader _Reader = new _Command.ExecuteReader())
        {
          while(_Reader.Read())
          {
            var1 = _Reader.GetInt32(0);
            var2 = _Reader.GetInt32(1);
            ProcessStuff(var1, var2);
            _ResultSet.SetString(0, something1);
            _ResultSet.SetSomething(1, something2);
            yield return _ResultSet;
          }
        }
      }
    }
