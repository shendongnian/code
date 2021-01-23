    using System.Text.RegularExpressions;
    static void Main()
    {
        string s = "My name is {Name} - {Gender}";
        Dictionary<string, List<string>> placeHolders = new Dictionary<string, List<string>>
        {
            {"Name", new List<string>{"FIRST", "LAST"}},
            {"Gender", new List<string>{"Male", "Female"}}
        };
        foreach(var item in placeHolders)
        {
            if (item.Value.Count == 2) item.Value.Add(string.Join(" ", item.Value));
        }
        var sSplit = Regex.Split(s, "(\\{[a-zA-Z]*\\})");
        List<string> results = new List<string> { "" };
        foreach (var item in sSplit)
        {
            Match m = Regex.Match(item, "{([a-zA-Z]*)}");
            if (!m.Success)
            {
                for (int i = 0; i < results.Count; i++) results[i] += item;
            }
            else
            {
                if (placeHolders.ContainsKey(m.Groups[1].Value))
                {
                    List<string> tempList = new List<string>();
                    foreach (var r in results)
                    {
                        foreach (var p in placeHolders[m.Groups[1].Value]) tempList.Add(r + p);
                    }
                    results = tempList;
                }
            }
        }
        foreach (var str in results)
            Console.WriteLine(str);
        Console.ReadLine();
    }
