    IEnumerable<string> ParseFile(string file)
    {
        using (FileStream stream =
                   new FileStream(file, FileMode.Open, FileAccess.Read,
                                  FileShare.ReadWrite | FileShare.Delete))
        using (LogReader reader = new LogReader(stream))
        {
            return (from x in reader.Parse()
                       .Where(y => y.IsInRange(range) &&
                              (y.EventNo == 1180 || y.EventNo == 1187) &&
                              y.GetDefaultMessageField().Contains(":Outbound/"))
                    group x by x.GetDefaultMessageField() into grouping
                    select new
                    {
                        ID = grouping.Key,
                        Event1180 = grouping.LastOrDefault(z => z.EventNo == 1180),
                        Event1187 = grouping.LastOrDefault(z => z.EventNo == 1187)
                    }).ToList();
        }
    }
