        private static void Main(string[] args)
        {
            var fileData = File.ReadAllBytes("Data.csv");
            var tableData = CreateDataTableFromFile(fileData);
            DataColumn dateColumn = tableData.Columns["Date"];
            Dictionary<string, List<FxConversionRate>> rates = new Dictionary<string, List<FxConversionRate>>();
            foreach (DataColumn column in tableData.Columns)
            {
                if (column != dateColumn)
                {
                    foreach (DataRow row in tableData.Rows)
                    {
                        FxConversionRate rate = new FxConversionRate();
                        rate.Currency = column.ColumnName;
                        rate.Date = DateTime.Parse(row[dateColumn].ToString());
                        rate.Rate = double.Parse(row[column].ToString());
                        if (!rates.ContainsKey(column.ColumnName))
                            rates.Add(column.ColumnName, new List<FxConversionRate>());
                        rates[column.ColumnName].Add(rate);
                    }
                }
            }
            foreach (var key in rates.Keys)
            {
                Console.WriteLine($"Found currency: {key}");
                foreach (var rate in rates[key])
                {
                    Console.WriteLine($"   {rate.Date.ToShortDateString()} : {rate.Rate:###,###,##0.00}");
                }
            }
            Console.WriteLine("Press any key");
            Console.ReadKey();
        }
        private static DataTable CreateDataTableFromFile(byte[] importFile)
        {
            var cb = new DelimitedClassBuilder("temp", ",") { IgnoreFirstLines = 0, IgnoreEmptyLines = true, Delimiter = "," };
            var ms = new MemoryStream(importFile);
            var sr = new StreamReader(ms);
            var headerArray = sr.ReadLine().Split(',');
            foreach (var header in headerArray)
            {
                cb.AddField(header, typeof(string));
                cb.LastField.FieldQuoted = true;
                cb.LastField.QuoteChar = '"';
            }
            var engine = new FileHelperEngine(cb.CreateRecordClass());
            return engine.ReadStreamAsDT(sr);
        }
