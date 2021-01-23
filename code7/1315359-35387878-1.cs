    ratingList.Sort();
    var count = ratingList.Count();
    
    // if even number of players, keep aside the one in the middle (as rating)
    int? middle = null;
    if (count % 2 != 0)
    {
        middle = ratingList[count / 2];
        ratingList.RemoveAt(count / 2);
    }
    
    var ratingListDesc = ratingList.OrderByDescending(i => i).ToList();
    var half = count / 2;
    var take = half % 2 != 0 ? half - 1 : half;
    var team1List = ratingList.Take(take).Where((r, i) => i % 2 == 0).ToList();
    team1List.AddRange(ratingListDesc.Take(take).Where((r, i) => i % 2 == 0));
    var team2List = ratingList.Take(take).Where((r, i) => i % 2 != 0).ToList();
    team2List.AddRange(ratingListDesc.Take(take).Where((r, i) => i % 2 != 0));
    // we just have to redistribute the remaining pair between each team
    if (half % 2 != 0)
    {
         team1List.Add(ratingList[half - 1]);
         team2List.Add(ratingListDesc[half - 1]);
    }
    
    if (middle.HasValue)
    {
        // do something, or not ...
    }
