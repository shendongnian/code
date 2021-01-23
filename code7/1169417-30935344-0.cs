    var result = query.Where(specification.IsSatisfiedBy())
                      .OrderBy(m => m.CreationDate)
                      .AsEnumerable() // From this point onward the query
                                      // will be executed C#-side
                      .Select(m => _messageModelHelper.BuildMessageModel(m));
