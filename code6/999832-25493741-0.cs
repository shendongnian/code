    var cleanedList = fooList.Where(f => f.Bars.Any(b => b.IsActive))
                             .Select(f => {
                                              f.Bars.RemoveAll(b => !b.IsActive); 
                                              return f;
                                          }
                                     );
