    List<int> lCVars = new List<int>();
    HashSet<int> hCVars = new HashSet<int>();
    var rnd = new Random();
    var randCVarsCount = 5;
    while (hCVars.Count < randCVarsCount)
    {
        var num = rnd.Next(1, 11);
        if (hCVars.Contains(num))
            Console.WriteLine("already in there");
        hCVars.Add(num);
    }
    lColVars = hsColVars.ToList();
