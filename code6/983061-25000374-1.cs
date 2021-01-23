    var repositoriesImp = typeof(SqlDataRepository).Assembly.GetExportedTypes()
                                      .Where(t => t.Name.EndsWith("Repository"))
                                      .ToList();
    var dictionary = new Dictionary<Type, Type>();
    foreach (var repositoryImp in repositoriesImp)
    {
        var repository = typeof(DataRepository).Assembly.GetExportedTypes()
                                         .Where(t => repositoryImp.IsSubclassOf(t))
                                         .Single();
        dictionary.Add(repository, repositoryImp);
    }
