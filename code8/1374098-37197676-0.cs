    Dictionary<string, string> dic = new Dictionary<string, string>();
    for (int i = 0; i < 11998949; i++) //11998949 is max supported range
    {
        dic.Add(i.ToString(), i.ToString());
    }
    
    Stopwatch sw = new Stopwatch();
    sw.Start();
    string Query = "some 11998948 input"; 
    foreach(var a in dic.Where(a=> Query.Contains(a.Key)))
    {
        Console.WriteLine($"Found {a.Key} in string {Query} in time {sw.ElapsedMilliseconds}ms");
    }
    Console.ReadKey();
