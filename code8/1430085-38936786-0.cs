    public Dictionary<string, int> Items = new Dictionary<string, int>();
    ...
    string[] rows = itemList.text.Split('\n');
    foreach (string row in rows)
    {
        string[] data = row.Split(':');
        int i;
        if (data.Length > 1 && int.TryParse(data[1].Trim(), out i))
            Items.Add(data[0].Trim(), i);
    }
