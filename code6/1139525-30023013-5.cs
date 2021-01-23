    var mergedList = new List<One>(YourFirstList.Count +
                                   YourSecondList.Count +
                                   YourThirdList.Count);
    mergedList.AddRange(YourFirstList);
    mergedList.AddRange(YourSecondList);
    mergedList.AddRange(YourThirdList);
