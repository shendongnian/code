     if (reader.Name == "Result")
     {
         DataRow workRow = dt.NewRow();
         
         //Just a suggestion
         if (columns.Contains(reader.Name))
         {
              workRow[reader.Name] = reader.Value;
         }
     }
    
     
