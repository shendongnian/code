    public class CsvLineItem
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public double Value1 { get; set; }
        public double Value2 { get; set; }
    }
    public static class CsvReader
    {
        public static IList<CsvLineItem> Read(string csvFilename)
        {
            var items = new List<CsvLineItem>();
            using (var connection = new OleDbConnection(
                @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source="
                    + Path.GetDirectoryName(csvFilename)
                    + ";Extended Properties=\"Text;HDR=Yes;TypeGuessRows=0;ImportMixedTypes=Text\""))
            {
                connection.Open();
                using (var command = new OleDbCommand(@"SELECT * FROM [" + Path.GetFileName(csvFilename) + "]", connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            items.Add(new CsvLineItem
                            {
                                Id = reader.GetInt32(0), // By column index
                                Name = reader.GetString(reader.GetOrdinal("Name")), // By column name
                                Value1 = reader.GetDouble(2),
                                Value2 = reader.IsDBNull(3) ? 0 : reader.GetDouble(3) // Handling nulls
                            });
                        }
                    }
                }
            }
            return items;
        }
