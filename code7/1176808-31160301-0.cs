    var _searchResult = dbCars.Cars.Where(carItem => target_terms.Any(x => carItem.Title.Contains(x) ||
                                                                           carItem.Name.Contains(x) ||
                                                                           carItem.Comment.Contains(x)))
                                   .Select(carItem => new
                                   {
                                       carItem,
                                       Rank = target_terms.Any(x => carItem.Title.Contains(x)) ? 1 :
                                              target_terms.Any(x => carItem.Name.Contains(x)) ? 2 :
                                              target_terms.Any(x => carItem.Comment.Contains(x)) ? 3 : 0
                                   })
                                   .OrderBy(carItem => carItem.Rank);
