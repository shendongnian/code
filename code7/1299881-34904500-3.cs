    List<Record> records = new List<Record>();
    string line;
    System.IO.StreamReader file = new System.IO.StreamReader(filePath);
    while ((line = file.ReadLine()) != null)
    {
        string[] parts = line.Split('-');
        records.Add(new Record {
            X = float.Parse(parts[0].Trim(), NumberFormatInfo.InvariantInfo),
		    Y = float.Parse(parts[1].Trim(), NumberFormatInfo.InvariantInfo);
		    D = DateTime.Parse(parts[2].Trim(), DateTimeFormatInfo.InvariantInfo)});
    }
