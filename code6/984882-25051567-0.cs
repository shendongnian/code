    var t = ._venueRepository.Table.FirstOrDefault().GetType();
    for(int iterationCount = 1; iterationCount < MAX_ITERATIONS ; iterationCount++)
    {
    PropertyInfo itemNameProperty = t.GetProperty(String.Format("DiscItemName_{0}", iterationCount));
    PropertyInfo discItermProperty = t.GetProperty(String.Format("DiscItem_{0}", iterationCount));
    //Repeat the above for all properties.
    var query = from v in this._venueRepository.Table
                        join s in this._storeRepository.Table on v.VenueID equals s.VenueID
                        join w in this._workstationRepository.Table on s.StoreID equals w.StoreID
                        join t in this._tillSummaryRepository.Table on w.WorkstationID equals t.TillOpID
                                //Repeat the below for other properties
                        group new { itemNameProperty.GetValue(v), dicItemProperty.GetValue(v) , qDiscProperty.GetValue(v) } by new { itemNameProperty.GetValue(v) } into g
                        //Similarly do for the select new.
                        select new { Discount = g.Key, Amount = g.Sum(p => p.DiscItem_1), Qty = g.Sum(p => p.QDiscItem_1) };
    
    //Other code here.
    }
