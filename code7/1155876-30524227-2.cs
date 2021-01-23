    // fixed length mask
    int[] mask = { 12, 6 };
    int maskLength = mask.Length;
    
    // modified code (replace with your file path)
    DataTable dt = new DataTable();
    dt.Columns.Add("COL1"); dt.Columns.Add("COL2"); dt.Columns.Add("COL3");
    string[] lines = File.ReadAllLines(@"D:\Temp\text.txt");
    foreach (var line in lines)
    {
        DataRow dr = dt.NewRow();
        int pos = 0;
        for (int i = 0; i < maskLength; pos += mask[i++])
        {
            dr[i] = line.Substring(pos, mask[i]).Trim();
        }
        dr[maskLength] = line.Substring(pos).Trim();
        dt.Rows.Add(dr);
    }
