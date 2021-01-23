    string p = "1,2,3;4,5,6&1,5,3;4,5,9";
    List<List<List<string>>> result = new List<List<List<string>>>();
    foreach (var a in p.Split('&'))
    {
        List<List<string>> level2 = new List<List<string>>();
        foreach (var b in a.Split(';'))
        {
            level2.Add(new List<string>(b.Split(',')));
        }
        result.Add(level2);
    }
    var x = result[0][1][2]; // This will result in '6'.
