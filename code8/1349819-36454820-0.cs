            stream = new MemoryStream();
            writer = new StreamWriter(stream);
            csvWriter = new CsvWriter(writer);            
            csvWriter.Configuration.QuoteAllFields = false;
            csvWriter.Configuration.HasHeaderRecord = true;
            csvWriter.WriteField("Number of TimeSeries");
            csvWriter.WriteField("add.firstVal(ms)");
            csvWriter.WriteField("add.secondVal (ms)");
            csvWriter.NextRecord();
            foreach (var resultSet in timeResults)
            {
               csvWriter.WriteField(resultSet.Key);
               foreach (var result in resultSet.Value)
               {
    
                  csvWriter.WriteField(result.Key);
                  csvWriter.WriteField(result.Value));  
               }    
               csvWriter.NextRecord();
             }
            writer.Flush();
           // do what you need with the data in the stream.
           // dispose objects.
