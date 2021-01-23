    public Dictionry<string, object> PrepareQueryValues(SearchModel query)
    {
         cleanQuery(query);
    
         Dictionary<string, object> dic = new Dictionary<string, object>();
         dic.Add("InactiveForDay", getinactiveForDays());
         dic.Add("SearchProfileGroups",_manager.GetSearchProfileGroupsForSite(query.PropertyType)); 
         dic.Add("SearchProfileGroups", setLocationOfInterest(query));
         dic.Add("SearchBounds", _manager.GetSearchBounds(query.StreetID, query.SublocalityID));
         dic.Add("ShopsList", getShops());
     
         return dic;         
    }
