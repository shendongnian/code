    var result = from f in _dbContext.FileLists
                 group f by f.Extension into g
                 let firstCategory = _dbContext.ExtensionsCategories
                                               .FirstOrDefault(x => x.Extension == g.Key)
                 select new
                        {
                            Category = firstCategory != null ? firstCategory.Category : "",
                            TotalFileCount = g.Count()
                        };
