     private static DataTable GetDataTabletFromCSVFile(string path)
     {
        DataTable csvData = new DataTable();        
        try
        {           
            using (TextFieldParser csvReader = new TextFieldParser( path))
            {
               csvReader.SetDelimiters(new string[] { "," });
               csvReader.HasFieldsEnclosedInQuotes = true;
               string[] colFields = csvReader.ReadFields();
               foreach (string column in colFields)
               {
                   DataColumn serialno = new DataColumn(column);
                   serialno.AllowDBNull = true;                   
                   csvData.Columns.Add(serialno);
               }
               while (!csvReader.EndOfData)
               {
                    string[] fieldData = csvReader.ReadFields();
                    DataRow dr = csvData.NewRow();
                    //Making empty value as null
                    for (int i = 0; i < fieldData.Length; i++)
                    {
                       if (fieldData[i] == "")
                       {
                           fieldData[i] = null;
                       }
                       dr[i] = fieldData[i];
                    }
                    csvData.Rows.Add(dr);              
                }
            }
        }
        catch (Exception ex)
        {
        }
        return csvData;
    }
