    var rows = File.ReadAllLines(tempPath).Skip(1)
                                          .Where(c =>
                                          {
                                               string[] args = c.Split('\t');
                                               return args[3] != "N/A";
                                          })
                                          .Select(c => 
                                          {
                                              string[] args = c.Split('\t');
                                              return new
                                              {
                                                  foo = args[3]
                                              };
                                          }).Distinct();
