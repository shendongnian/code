    string value = "content;123 contents;456 contentss;789";
    Dictionary<string, int> data = new Dictionary<string,int>();
    foreach(string line in value.Split(' '))
    {
        string[] values = line.Split(';');
        if (!data.ContainsKey(values[0]))
        {
            data.Add(values[0], Convert.ToInt32(values[1]));
        }
    }
