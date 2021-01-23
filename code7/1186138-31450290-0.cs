    StringBuilder batch = new StringBuilder();
    for (int i = 0; i < 100; i++)
    {
      batch.AppendFormat(
        @"INSERT INTO [Obj CA MPX] ([CA TTC],[VAL MRG TTC], ...) VALUES(@ca{0},@val{0}, ...)"
        i);
      batch.AppendLine();
      batch.AppendLine();
    }
    
    SqlCommand command = new SqlCommand(batch.,ToString(), con)
    command.
    
    // append parameters, using the index
    for (int i = 0; i < 100; i++)
    {
      command.Parameters.Add("@date" + i, SqlDbType.Date).Value = dt1;
      command.Parameters.AddWithValue("@ca" + i, s1);
      // ...
    }
    command.ExecuteNonQuery();
