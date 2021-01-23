    return _Collection.GroupBy(e => _GetElem(e))
                      .Select(f => new
                      {
                          Count = f.Count(),
                          Elem = f.Key
                      })
                      .OrderByDescending(g => g.Count)
                      .FirstOrDefault()?
                      .Elem;
