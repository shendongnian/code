    string input = "test - qweqw(Barcelona - Bayer) - testestsetset";
    string res = String.Join("", input.SkipWhile(c => c != '(')
                                      .SkipWhile(c => c != '-').Skip(1)
                                      .TakeWhile(c => c != ')'))
                       .Trim();
    Console.WriteLine(res);  // Bayer
