    using System;
    using System.Collections.Generic;
    using System.IO;
    
    namespace ConsoleApplication19
    {
      public class Program
      {
        private readonly static String _testData = @"
    test information
    annoying information
    Subscribed      more annoying info
                more annoying info
    
    dvd = 234,
    cls = 453,
    jhd = 567,
    
    more annoying info
    more annoying info
    
    dxv = 456,
    hft = 876;
    
    more annoying info
    
    test information
    annoying information
    Subscribed      more annoying info
                more annoying info
    
    dvd = 234,
    cls = 455,
    
    more annoying info
    more annoying info
    
    dxv = 456,
    hft = 876,
    jjd = 768;
    
    more annoying info
    
    test information
    annoying information
    Disconnected        more annoying info
                more annoying info
    
    
    
    more annoying info";
    
        public static void Main(String[] args)
        {
          /* Create a temporary file containing the test data. */
          var testFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), Path.GetRandomFileName());
          File.WriteAllText(testFile, _testData);
    
          try
          {
            var p = new Program();
            var records = p.GetRecords(testFile);
    
            foreach (var kvp in records)
            {
              Console.WriteLine("Record #" + kvp.Key);
              foreach (var entry in kvp.Value)
              {
                Console.WriteLine("  " + entry);
              }
            }
          }
          finally
          {
            File.Delete(testFile);
          }
        }
    
        private Dictionary<String, List<String>> GetRecords(String path)
        {
          var results = new Dictionary<String, List<String>>();
          var recordNumber = 0;
          var isInRecord = false;
    
          using (var reader = new StreamReader(path))
          {
            String line;
    
            while ((line = reader.ReadLine()) != null)
            {
              line = line.Trim();
    
              if (line.StartsWith("Disconnected"))
              {
                // needs to continue on search for Disconnected or Subscribed
                isInRecord = false;
              }
              else if (line.StartsWith("Subscribed"))
              {
                // program needs to continue reading file
                // looking for and assigning values to
                // dvd, cls, jhd, dxv, hft
    
                // records start at Subscribed and end at ;
    
                isInRecord = true;
                recordNumber++;
              }
              else if (isInRecord)
              {
                // Check if the line has a general format of "something = something".
                var parts = line.Split("=".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length != 2)
                  continue;
    
                // Update the relevant dictionary key, or add a new key.
                List<String> entries;
                if (results.TryGetValue(recordNumber.ToString(), out entries))
                  entries.Add(line);
                else
                  results.Add(recordNumber.ToString(), new List<String>() { line });
    
                // Determine if the isInRecord state variable should be toggled.
                var lastCharacter = line[line.Length - 1];
                if (lastCharacter == ';')
                  isInRecord = false;
              }
            }
          }
    
          return results;
        }
      }
    }
