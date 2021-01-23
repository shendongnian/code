     class CsvUtility
    {
        public DataTable Csv2DataTable(string fileName, bool includeHeader = false, char separator = ',')
        {
            IEnumerable<string> reader = File.ReadAllLines(fileName);
            var data = new DataTable("Table");
            var headers = reader.First().Split(separator);
            if (includeHeader)
            {
                foreach (var header in headers)
                {
                    data.Columns.Add(header.Trim());
                }
                reader = reader.Skip(1);
            }
            else
            {
                for (int index = 0; index < headers.Length; index++)
                {
                    var header = "Field" + index; // headers[index];
                    data.Columns.Add(header);
                }
            }
            foreach (var row in reader)
            {
                if (row != null) data.Rows.Add(row.Split(separator));
            }
            return data;
        }
        public string Csv2Xml(string fileName, bool includeHeader = false, char separator = ',')
        {
            var dt = Csv2DataTable(fileName, includeHeader, separator);
            var stream = new StringWriter();
            dt.WriteXml(stream);
            return stream.ToString();
        }
    }
