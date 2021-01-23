    var groupedVenueCollection = getTrustActivitiesFromStorage
        .GroupBy(customer => customer.venueName)
        .OrderBy(g => g.Key);
    foreach (var group in groupedVenueCollection)
    {
        TrustActivities firstActivity = group.First();
        filteredVenues.Add(new TrustActivities 
        { 
            filterId = Convert.ToInt32(firstActivity.venueId), 
            filterName = firstActivity.venueName,  // or group.Key
            filterCount = group.Count()  // <--- !!!
        });
    }
