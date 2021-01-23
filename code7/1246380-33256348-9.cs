    var result = extensionCat.GroupBy(x => x.Category)
                          .Select(x =>
                             new
                              {
                                  Category = x.Key,
                                  TotalFileCount = fileList.Count(f => x
                                                        .Any(z => z.Extension == f.Extension))
                              }
                          );
