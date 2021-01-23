    private  Dictionary<string, IEnumerable<string>> importData(string imports)
        {
          return imports.Split('\n')
                .Select(line => line.Split(':'))
                .GroupBy(line => line[0])
                .ToDictionary(line => line.Key,
                              line => line.Select(item => item[1])
                                          .Aggregate((c, n) => c.Insert(c.Length, ","+n))
                                          .Split(',')
                                          .Select(i => i.Trim(' '))
                                          .Distinct()
                             );
        }
