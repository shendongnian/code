    private void QueryByStruct(SqlCeCommand cmd, CTypedClass1 curRec)
    {
       if (cmd.Connection.State != ConnectionState.Open)
          cmd.Connection.Open();
       List<object> fields;
       using (var reader = cmd.ExecuteReader())
       {
          if (reader.Read())
          {
              var values = new Object[reader.FieldCount];
              reader.GetValues(values);
              fields = values.ToList();
          }
       }
    
       if (cmd.Connection.State == ConnectionState.Open)
          cmd.Connection.Close();
       curRec.Fld1 = (int)fields.ElementAt(1);
       curRec.Fld2 = (int)fields.ElementAt(2);
       // etc with rest of fields to 45
       // all explicitly (typecast) referenced
    }
