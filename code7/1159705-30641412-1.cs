    const char separator = ',';
    using (var reader = new StreamReader("C:\\sample.txt"))
    {
        var fields = (reader.ReadLine() ?? "").Split(separator);
        // Dynamically add the columns
        var table  = new DataTable();
        table.Columns.AddRange(fields.Select(field => new DataColumn(field)).ToArray());
        while (reader.Peek() >= 0)
        {
            var line = reader.ReadLine() ?? "";
            // Split the values considering the quoted field values
            var values = Regex.Split(line, ",(?=(?:[^\"]*\"[^\"]*\")*[^\"]*$)")
                .Select((value, current) => value.Trim())
                .ToArray()
                ;
            // Add those values directly
            table.Rows.Add(values);
        }
        // Demonstrate the results
        foreach (DataRow row in table.Rows)
        {
            Console.WriteLine();
            foreach (DataColumn col in table.Columns)
            {
                Console.WriteLine("{0}={1}", col.ColumnName, row[col]);
            }
        }
    }
