    private void CSVtoDataTable(string filepath)
    {
      int count = 1;            
      char fieldSeparator = ',';
      DataTable csvData = new DataTable();
         
      using (TextFieldParser csvReader = new TextFieldParser(filePath))
      {                   
          csvReader.HasFieldsEnclosedInQuotes = true;                  
          while (!csvReader.EndOfData)
          {
               csvReader.SetDelimiters(new string[] { "," });
               string[] fieldData = csvReader.ReadFields(); 
               if(count==0)
               {
                   foreach (string column in fieldData)
                   {
                      DataColumn datecolumn = new DataColumn(column);
                      datecolumn.AllowDBNull = true;
                      csvData.Columns.Add(datecolumn);
                   }
               }  
               else 
               {
                   csvData.Rows.Add(fieldData);
               }                  
           }
         }
     }
               
