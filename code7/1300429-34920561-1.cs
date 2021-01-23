    var groupedVenueCollection = getTrustActivitiesFromStorage
     .GroupBy(customer => customer.venueName)
     .OrderBy(g => g.Key)
     .Select(g => new { Activity = g.First(), Count = group.Count() })
     .Select(x => new TrustActivities 
        { 
            filterId = Convert.ToInt32(x.Activity.venueId), 
            filterName = x.Activity.venueName,
            filterCount = x.Count
        })
    .ToList();
