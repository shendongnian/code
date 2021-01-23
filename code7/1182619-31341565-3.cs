    var twiceNested = jsObject["coordinates"]
                        .First()
                        .Select(pair => new List<double> {
                                pair[0].Value<double>(), 
                                pair[1].Value<double>()
                            }
                        ).ToList();
    
    
    var result = new List<List<List<double>>> {twiceNested};
