        //current result set
        var resultIds = iQueryableResults.Select(s => s.Id).ToArray(); 
        //intersect with some other array of ints
        var intersection = resultIds.Intersect(priorResults).ToArray(); 
        //Total the results in the intersection
        var resultCount = intersection.Count();
       
        //Get an upper boundary for your loop.             
        var upperLimit = (resultCount >= ((filter.Skip + filter.Take) - 1))
                                         ? (filter.Skip + filter.Take) - 1
                                         : resultCount;
        var results = new List<MyReturnObject>();
        //Back to the basics
        for (int i = filter.Skip; i < upperLimit; i++)
        {
               var _id = intersection[i];
               results.Add(QueryAllMyObjects().FirstOrDefault(f => f.Id == _id));
        }
        return results;
