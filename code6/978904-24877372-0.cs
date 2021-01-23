    return File.ReadAllLines(path).Skip(1).Select(c =>
                                                     {
                                                         var split = c.Split('\t');
                                                         return new {
                                                             Name = split[0],
                                                             ID = split[1],
                                                             Address = split[2],
                                                             Car = split[3],
                                                             Weight = split[4],
                                                             Salary = split[5],
                                                             Married = split[6],
                                                             Kids = split[7],
                                                         };
                                                     }).GroupBy(c => c.Name);
