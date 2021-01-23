    var spaces = string.Join(",", Enumerable.Range(0, 0x10000)
                                  .Select(i => ((char)i))
                                  .Where(c => char.IsWhiteSpace(c))
                                  .Select(x => "'\\x" + Convert.ToInt16(x).ToString("x4") + "'"));
    Console.WriteLine(spaces);
