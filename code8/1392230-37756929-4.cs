    JContainer allPages = null;
    var settings = new JsonMergeSettings { MergeArrayHandling = MergeArrayHandling.Concat };
    for (int page = 0; page <= recCount; page += 2000)
    {
        //Get data
        var pageOne = (JContainer)getJsonData(page);
        if (allPages == null)
            allPages = pageOne;
        else
            allPages.Merge(pageOne, settings);
    }
    return allPages;
