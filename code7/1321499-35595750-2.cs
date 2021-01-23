    using System.Text.RegularExpressions;
    static void Main()
    {
        string s = "My name is {Name} - {Gender}";
        Dictionary<string, List<string>> level2 = new Dictionary<string, List<string>>
        {
            {"Name", new List<string>{"FIRST", "LAST"}},
            {"Gender", new List<string>{"Male", "Female"}}
        };
        foreach(var item in level2)
        {
            if (item.Value.Count == 2) item.Value.Add(string.Join(" ", item.Value));
        }
        var ss = Regex.Split(s, "(\\{[a-zA-Z]*\\})");
        List<string> results = new List<string> { "" };
        foreach (var item in ss)
        {
            Match m = Regex.Match(item, "{([a-zA-Z]*)}");
            if (!m.Success)
            {
                for (int i = 0; i < results.Count; i++) results[i] += item;
            }
            else
            {
                if (level2.ContainsKey(m.Groups[1].Value))
                {
                    List<string> list2 = new List<string>();
                    foreach (var s3 in results)
                    {
                        foreach (var s4 in level2[m.Groups[1].Value]) list2.Add(s3 + s4);
                    }
                    results = list2;
                }
            }
        }
        foreach (var str in results)
            Console.WriteLine(str);
        Console.ReadLine();
    }
