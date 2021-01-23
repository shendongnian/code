    using CsvHelper;
    using System;
    using System.IO;
    using System.Linq;
    namespace DataImport
    {
        class Program
        {
            static void Main(string[] args)
            {
                // .CSV file path
                Console.WriteLine("Absolute path to .csv file: ");
                string csvFilePath = Console.ReadLine();
                // Reading .csv file line by line and calling for SendingRecord method
                using (var reader = new StreamReader(csvFilePath))
                using (var csv = new CsvReader(reader))
            {
                csv.Configuration.HasHeaderRecord = false; // My file has no header lines, if yours have this must be 'true'
                csv.Configuration.ShouldSkipRecord = record => record.All(string.IsNullOrEmpty); // Skipping empty lines in .CSV file
                var records = csv.GetRecords<Products>().ToList();
                for (int i = 0; i < records.Count; i++)
                {
                    Mongo.SendingRecord(records[i]);
                }
            }
        }
    }
