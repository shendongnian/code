    var records = System.IO.File.ReadAllLines(path)
                                .Skip(1) // the header
                                .Select(c =>
                                           {
                                               var fields = c.Split(',');
                                               return new
                                               {
                                                   Date = DateTime.Parse(fields[0]),
                                                   Y = getDoubleOrNull(fields[1]),
                                                   X1 = getDoubleOrNull(fields[2]),
                                                   X2 = getDoubleOrNull(fields[3]),
                                                   X3 = getDoubleOrNull(fields[4]),
                                                   X4 = getDoubleOrNull(fields[5]),
                                               };
                                           });
