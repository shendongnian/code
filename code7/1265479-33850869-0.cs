    string s = "on top on bottom on side Works this Magic door";
    Regex r = new Regex(@"\bon\W+(?:\w+\W+){0,4}side\b");
    int output = 0;
    int start = 0;
    while (start < s.Length)
    {
        Match m = r.Match(s, start);
        if (!m.Success) { break; }
        Console.WriteLine(m.Value);
        output++;
        start = m.Index + 1;
    }
    Console.WriteLine(output);
