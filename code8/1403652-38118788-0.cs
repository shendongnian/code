    var cd = campaigns.GroupBy (c => new {c.ID} ).Select (cp =>
         new {
            cId= cp.Key.ID,
            TotalUsers = cp.Count(),
            TotalSum= cp.Sum( x=>x.UsersByCampaign)
            ...
            } );
    var results = campaignList.ForEach( cl => cd.Where( cdd => cdd.cId == cl.Id)
    .Select(cdd => new { CampaignId  = cdd.CId, TotalVisitors  = cdd.TotalUsers , .. })
    .DefaultIfEmpty( new { CampaignId  = cdd.CId, TotalVisitors  =0 , .. });
