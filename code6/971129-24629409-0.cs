    string str = "0,A 1,B 2,C 3,D 4,E";
    var pairs = str.Split().Select(p => p.Split(',')).Select(p => new
                                                               {
                                                                   Key = p[0],
                                                                   Value = p[1]
                                                               });
    string[] keys = pairs.Select(p => p.Key).ToArray();
    string[] values = pairs.Select(p => p.Value).ToArray();
