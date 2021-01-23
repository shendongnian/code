    using (OdbcDataReader DbReader = DbCommand.ExecuteReader())
        {
           int fCount = DbReader.FieldCount;
           while (DbReader.Read())
             {
                  Label1 = DbReader.GetString(0);
                  Label2 = DbReader.GetString(1);
                  Label3 = DbReader.GetString(2);
                  Label4 = DbReader.GetString(3);
                  for (int i = 0; i < fCount; i++)
                    {
                       String col = DbReader.GetString(i);
                        Console.Write(col + ":");
                    }
                    Console.WriteLine();
            }
    }
