    using (var db = new YourContext())
    {
          var cmd = db.Database.Connection.CreateCommand();
          cmd.CommandText = "YourStoredProcedure";
          db.Database.Connection.Open();
          var reader = cmd.ExecuteReader();
          ObjectResult<HelloClass> table1 = ((IObjectContextAdapter)db).ObjectContext.Translate<HelloClass>(reader, "HelloClass", MergeOption.AppendOnly);
          reader.NextResult();
          ObjectResult<HelloClass2> table2 = ((IObjectContextAdapter)db).ObjectContext.Translate<HelloClass2>(reader, "HelloClass2", MergeOption.AppendOnly);
    }
