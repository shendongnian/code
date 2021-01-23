    using (SqlDataReader reader = exportCmd.ExecuteReader()) {
            using (StreamWriter writer = new StreamWriter(exportFilename))
            {
              string Separator = ",";
              while (reader.Read())
              {
                for (int columnCounter = 0; columnCounter < reader.FieldCount; columnCounter++)
                {
                  if (columnCounter > 0)
                  {
                    writer.Write(Separator);
                  }
                  writer.WriteLine(reader.GetValue(columnCounter).ToString());
                }
              }
            }
          }
