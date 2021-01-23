    var allResults = new List<T>; //where T is whatever object type this is (FuelConsumptionRateQueryResult?)
    
    foreach (int assetId in assetIds)
    { 
        //this is a new variable at each iteration of the loop
        FuelConsumptionRateQueryResult result = FuelConsumptionRateQueryService.Get(assetId, from, to, AssetCounterType.Odometer);
        allResults.Add(result); //add the current result to your list (outside the scope of this loop)
    }
