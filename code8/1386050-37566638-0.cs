     List<CoordNew> newlist = listCoord .Join(strDictionary, 
                                     a => a.Segment, //From listCoord
                                     b => b.Key, //From strDictionary
                                     (a, b) => new CoordNew() { 
                                          Segment_dictionaryValue = b.Value
                                          //Other values from list or dictionary
                                     }).ToList();
