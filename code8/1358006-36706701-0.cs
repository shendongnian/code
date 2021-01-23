    using (var reader = File.CreateText("C:\\procedure.txt"))
    {
        // Starting outer json array
        reader.WriteLine("[");
        for (var rowIndex = 0; rowIndex < myTable.Rows.Count; rowIndex++)
        {
            var row = myTable.Rows[rowIndex];
            var rowValues = new List<string>(); // can be reused if needed
            foreach (DataColumn column in myTable.Columns)
                rowValues.Add(row[column].ToString());
            var jsonRow = JsonConvert.SerializeObject(rowValues);
            // Write current row
            reader.Write(jsonRow);
            // Add separating comma
            if (rowIndex != myTable.Rows.Count - 1)
                reader.WriteLine(",");
        }
        // End outer json array
        reader.WriteLine("]");
    }
