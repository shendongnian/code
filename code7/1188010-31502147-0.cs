    // build up a data table of numbers
    DataTable dataTable = new DataTable();
    dataTable.Columns.Add("StationId", typeof(int));
    Random r = new Random();
    for (int i = 0; i < 5000; i++)
    {
        var dataRow = dataTable.NewRow();
        dataRow["StationId"] = r.Next(1000, 9999);
        dataTable.Rows.Add(dataRow);
    }
    // get all the numbers in the list
    HashSet<int> allNumbers = new HashSet<int>(dataTable.AsEnumerable().Select(a => (int)a["StationId"]));
            
    // between 1000-9999, find numbers not in the set
    List<int> missingNumbers = Enumerable.Range(1000, 9000)
        .Where(a => !allNumbers.Contains(a))
        .Select(a => a).ToList();
    // convert to a string
    string result = String.Join(Environment.NewLine, missingNumbers.ConvertAll<string>(a => a.ToString()));
            
