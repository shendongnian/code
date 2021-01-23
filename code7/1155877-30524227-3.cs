    // regular expression for split row:
    Regex parser = new Regex(@"\s+");
    
    // modified code (replace with your file path)
    DataTable dt = new DataTable();
    dt.Columns.Add("COL1"); dt.Columns.Add("COL2"); dt.Columns.Add("COL3");
    string[] lines = File.ReadAllLines(@"D:\Temp\text.txt");
    foreach (var line in lines)
    {
        DataRow dr = dt.NewRow();
        string[] words = parser.Split(line);
        dr[0] = words[0];
        dr[1] = words[1];
        dr[2] = words[2];
        dt.Rows.Add(dr);
    }
