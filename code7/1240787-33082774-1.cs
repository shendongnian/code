    public static class FileInfoExtension
    {
        public static IEnumerable<MyRecord> ReadMyRecords(this FileInfo file, char separator)
        {
            var records = new List<MyRecord>();
            using (var reader = new StreamReader(file.FullName))
            {
                var lineToProcess = reader.ReadLine();
                while (lineToProcess != null)
                {
                    var splitLines = lineToProcess.Split(new char[] { separator }, 3);
                    if (splitLines.Length < 3) throw new InvalidDataException();
                    var record = new MyRecord()
                    {
                        Rec = splitLines[0],
                        CountryCode = splitLines[1],
                        Year = Int32.Parse(splitLines[2]),
                    };
                    records.Add(record);
                    lineToProcess = reader.ReadLine();
                }
            }
            return records;
        }
    }
