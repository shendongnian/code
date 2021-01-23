    // load both files
    List<string[]> lstBoth = File.ReadAllLines(@"C:\Temp\1.csv").
                        Select(line => line.Split(';')).
                        Concat(File.ReadAllLines(@"C:\Temp\2.csv").
                        Select(line => line.Split(';'))).ToList();
    // GroupBy element[1] unioned with element[2] groups,
    // select the unique ones (count == 1)
    // pull the original data out of the type
    var rezLst = lstBoth.GroupBy(g => g[1],
                (name, values) => new
                {
                    Data = string.Join(";", values.ToArray()[0]),
                    Count = values.Count()
                }).Where(q => q.Count == 1).
                Union(
                    lstBoth.GroupBy(g => g[2],
                    (name, values) => new
                    {
                        Data = string.Join(";", values.ToArray()[0]),
                        Count = values.Count()
                    }).Where(q => q.Count == 1)
                ).Select(q => q.Data).ToList();
