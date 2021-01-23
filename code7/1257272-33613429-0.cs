    List<Result> AllResults = new List<Result>();
    Parallel.ForEach(allIDs, () => new List<Result>(), (id, loopState, subList) =>
    {
       subList.Add(GetResultFor(id));
       return subList;
    },
    subList => 
    { 
         lock(AllResults)
             AllResults.AddRange(subList); 
    });
