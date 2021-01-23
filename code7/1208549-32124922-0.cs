    public void nameCSV()
    {
        var reader = new StreamReader(File.OpenRead(@"C:\temp\nameList.csv"));
        Dictionary<string, int> userDict = new Dictionary<string, int>();
        while (!reader.EndOfStream)
        {
            var line = reader.ReadLine();
            var values = line.Split(',');
            userDict.Add(values[0], values[1]);
        }
        cmbxName.DataSource = userDict;
    }
