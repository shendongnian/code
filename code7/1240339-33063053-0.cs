    var result = System.Web.Helpers.WebCache.Get('keyToYourData');
    if (result == null) 
    {
        // cache wasn't created yet, create it and set it into the cache
        result = LoadMyData();
        System.Web.Helpers.WebCache.Set('keyToYourData', result);
    }
    return result;
