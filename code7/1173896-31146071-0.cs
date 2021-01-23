           for (int j = 0; j < ds.Tables[i].Columns.Count; j++)
              {
                  if(ds.Tables[i].Columns[j].DataType==typeof(string))
                  ds.Tables[i].Columns[j].DefaultValue = "empty string";
              
              }
                    
   }
