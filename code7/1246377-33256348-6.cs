    var result = extensionCat.GroupBy(x => x.Category)
                     .Select(x =>
                       {
                            var files = fileList.Where(f => x.Select(z => z.Extension)
                                                 .Contains(f.Extension)).Count();
                                  return new
                                  {
                                      Category = x.Key,
                                      TotalFileCount = files
                                  };
                              });
