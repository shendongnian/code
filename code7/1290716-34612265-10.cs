    public DataTable readCSV(string filePath)
    {
        var dt = new DataTable();
        var csv = new CsvReader(new StreamReader(filePath));
        // Creating the columns
        typeof(Person).GetProperties().Select(p => p.Name).ToList().ForEach(x => dt.Columns.Add(x));
        // Adding the rows
        csv.GetRecords<Person>().ToList.ForEach(line => dt.Rows.Add(line.Name, line.Age, line.Birthdate, line.Working));
        return dt;
    }
