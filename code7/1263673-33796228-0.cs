    var result = firstCollection.Join(secondCollection, 
                                      a => new { a.CustomerId, a.City }
                                      b => new { b.CustomerId, b.City },
                                      GetDifferences)
                                .SelectMany(x => x)
                                .Where(x => x != null).ToList();
