    List<string> letters = new List<string> { "a", "b", "c" };
    List<string> types = new List<string> { "Name", "Class", "Score" };
    List<int> ints = Enumerable.Range(1, 4).ToList();
    foreach (string type in types)
    {
        foreach (string letter in letters)
        {
            foreach (int i in ints)
            {
                dt.Columns.Add($"{type}_{letter}{i.ToString()}");
            }
        }
    }
