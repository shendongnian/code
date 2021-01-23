    var filtered =    //This is an IEnumerable of KeyValuePair<Tuple<int, string, string, int, string>, double>
        dctMC.Where(Z => listIDs.Contains(Z.Key.Item1) && 
                                            Z.Key.Item2 == "Apple" && 
                                            Z.Key.Item4 == 9 && 
                                            Z.Key.Item5 == "Green") 
    var values   = filtered.Select(item => item.Value);  //the doubles you want to sum
    double TOTAL = values.Sum();                         //The sum you were looking for...
