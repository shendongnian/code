     public void FindProvider()
     {
          var reader = OleDbEnumerator.GetRootEnumerator();
          var list = new List<String>();
          while (reader.Read())
          {
               for (var i = 0; i < reader.FieldCount; i++)
               {
                    if (reader.GetName(i) == "SOURCES_NAME")
                    {
                         list.Add(reader.GetValue(i).ToString());
                    }
               }
          }
          reader.Close();
          foreach (var provider in list)
          {
               if (provider.StartsWith("Microsoft.ACE.OLEDB"))
               {
                    this.provider = provider.ToString();
               }
          }
     }
