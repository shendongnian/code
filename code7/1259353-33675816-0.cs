    int[] listNames = {"List1", "List2"};
    
    //Create a datatable to hold your results
    var result = new DataTable();
    //Iterate over your listnames and fetch the data
    foreach (int listName in listNames)
    {
        BuildSiteQuery(siteQuery, listName );
        //Merge the results 
        result.Merge(web.GetSiteData(siteQuery));
    }
