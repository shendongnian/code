    string[] first = { "A", "C", "A", "A", "B", "B", "A", "A" };
    int[] second = { 1, 1, 2, 3, 1, 10, 5, 7 };
    var list = first.Zip(second, (f, s) => new { First = f, Second = s });
    Dictionary<string, int[]> d = list.GroupBy(i => i.First)
                                      .ToDictionary(k => k.Key, v => v.Select(val => val.Second)
                                                                      .ToArray()
                                                   );
