    List<CSVEntry> csvlist = new List<CSVEntry>();
    for (int i = 0; i < lines.Length; i++)
    {
        string[] data = lines[i].Split(new string[] { "," }, StringSplitOptions.None);
        csvlist.Add(new CSVEntry() { EntryNo = Int32.Parse(data[0]), Date = DateTime.ParseExact(data[1], "dd/MM/yyyy", null), Text = data[2] });
    }
