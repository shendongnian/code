    // some test data...
    var rand = new Random();
    StringBuilder sb = new StringBuilder();
    for (int i = 1; i <= 10000; i++)
    {
        sb.Append(i.ToString("000000") + ((rand.Next(5)==1) ? "  ": "\t"));
    }
    string s = sb.ToString();
    
    string portion = string.Join("  ", s.Split(new [] {' ', '\t'}, StringSplitOptions.RemoveEmptyEntries).Skip(10).Take(3));
    
    Console.WriteLine(portion); // outputs "000011  000012  000013"
    
