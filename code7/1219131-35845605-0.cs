    using (StreamWriter sw = new StreamWriter(@"C:\output.csv"))
    {
      using (CsvWriter writer = new CsvWriter(sw))
      {
         writer.WriteHeader<YourClass>();
    
         writer.WriteRecord(yourRecordVariable);
      }
    }
