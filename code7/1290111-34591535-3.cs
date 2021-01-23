    string html = File.ReadAllText("C:\\Temp\\html.txt");  // loading your sample from file
    DataTable table = GetTable(html, "table", true);
    string nick = "robbie_william";  // input example
    bool isContained = table.AsEnumerable()
        .Any(r => nick.Equals(r.Field<string>("nick"), StringComparison.InvariantCultureIgnoreCase));
