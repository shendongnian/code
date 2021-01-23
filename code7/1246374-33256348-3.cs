    var result = _dbContext.FileLists.GroupBy(e => e.Extension)
                  .Select(x =>
                      {
                          var firstCategory = _dbContext.ExtensionsCategories
                                               .FirstOrDefault(z => z.Extension == x.Key);
                          return new
                            {
                               Category = firstCategory != null ? firstCategory.Category : "",
                               TotalFileCount = x.Count()
                            };
                      });
