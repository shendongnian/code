    var records = System.IO.File.ReadAllLines(path).Skip(1).Select(c =>
                                                                   {
                                                                       var fields = c.Split(',');
                                                                       return new {
                                                                           Date = DateTime.Parse(fields[0]),
                                                                           Y = double.Parse(fields[1]),
                                                                           X1 = double.Parse(fields[2]),
                                                                           X2 = double.Parse(fields[3]),
                                                                           X3 = double.Parse(fields[4]),
                                                                           X4 = double.Parse(fields[5]),
                                                                       };
                                                                   });
