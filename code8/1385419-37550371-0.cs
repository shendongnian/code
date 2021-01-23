    List<Business> businessList = new List<Business>();
    
    #region Fill the business list
    ............................... 
    #endregion
  
    if (businessList.Count == 1000) // the size of the bulk.
    {
         EsClient.IndexMany<Business>(businessList, IndexName);
    
         businessList.Clear();
    }
