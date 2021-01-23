        List<string> ints = new List<string>();
        ints.Add("F12");
        ints.Add("T16");
        ints.Add("K15");
        ints.Add("F10");
        ints.Add("K14");
        ints.Add("T9");
        ints.Add("T7");
        var ordered = ints.Select((s, i) => new
        {
            nb = int.Parse(s.Substring(1)),
            text = s.Substring(0, 1),
            val = s,
        }).OrderBy(arg => arg.text).ThenBy(arg => arg.nb).ToList();
        var index = ordered.FindIndex(arg => arg.val == "T16");
        Console.WriteLine(ordered[index - 1].val);
        Console.ReadLine();
