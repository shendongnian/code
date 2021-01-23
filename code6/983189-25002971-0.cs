    var rows = File.ReadAllLines(filePath).Select(c => 
                                                  {
                                                      string[] args = c.Split(\t);
                                                      return new
                                                      {
                                                          Col1 = args[0],
                                                          Col2 = args[1],
                                                          Col3 = args[2],
                                                          Col4 = args[3],
                                                          Col5 = args[4],
                                                          Col6 = args[5],
                                                          Col7 = args[6],
                                                          Col8 = args[7]
                                                      };
                                                  }).ToArray(); // I wouldn't use ToArray here if you were only looking for one grouping, since that would be less efficient on memory and CPU usage
    var groupedByThree = rows.GroupBy(c => c.Col1 + c.Col2 + c.Col3);
    var groupedByFive = rows.GroupBy(c => c.Col1 + c.Col2 + c.Col3 + c.Col4 + c.Col5);
