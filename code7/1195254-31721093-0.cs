    public Enums.GYRStatus GetStatusForTransformer(
                string factoryCode, 
                Enums.Technology technology, 
                string transformerType,
                int transformerSize,
                string transformerModel)
    {
       Enums.GYRStatus retValue=(Enums.GYRStatus)1;
       fakeStandardsAndSizesFictionary = new Dictionary<Tuple<string,
                                                        Enums.Technology,
                                                        string, int, string>, int>() 
       {
           { Tuple.Create("SELUD", Technology.CVT,"---", 0, ""), 1} };
       }
    
       foreach (var pair in fakeStandardsAndSizesFictionary)
       {
           if (pair.Key.Item1 == factoryCode &&
              pair.Key.Item2 == technology &&
              pair.Key.Item3 == transformerType &&
              pair.Key.Item4 == transformerSize &&
              pair.Key.Item5 == transformerModel)
               retValue = (Enums.GYRStatus)pair.Value;
       }
       return retValue; 
    }
