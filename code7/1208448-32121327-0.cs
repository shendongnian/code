          string[] fields = new string[]{
                                   
                                    "passport_number",
                                    "applicant_name",
                                    //and so on you should write all of your columns which you wanna update.
                                };
          foreach (DataRow sourceRow in dt1.Rows)
          {
               var searchResult = from dRow in dt2.AsEnumerable()
                                  where dRow["FILE_NAME"].Equals(sourceRow["FILE_NAME"])
               select dRow;
               
               if(!searchResult.Any())
                   continue;
               
               
               
               foreach(string columnName in fields)
               {
                   searchResult[columnName] = sourceRow[columnName];
               } 
               
          }
          
          
