    class TempRecord
    {
        public string FirstCol { get; set; }
        public string LastCol { get; set; }
    }
    class FooterRecord
    {
        public string FooterText { get; set; }        
    }
    class Program
    {
        static void Main(string[] args)
        {
            var tempRecords = new List<TempRecord>();
            tempRecords.Add(new TempRecord{FirstCol = "row1a", LastCol="row1z"});
            tempRecords.Add(new TempRecord{FirstCol = "row2a", LastCol="row2z"});
            var outputCsv = @"M:\temp\temp.csv";            
            using (TextWriter writer = File.AppendText(outputCsv))
            {
                var csv = new CsvWriter(writer);
                csv.Configuration.HasHeaderRecord = true;
                csv.WriteRecords(tempRecords);
                csv.WriteRecord(new FooterRecord { FooterText = "Hey! THis is a footer" });
            }
            
        }
    }
