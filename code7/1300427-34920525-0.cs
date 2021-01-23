    IEnumerable<TrustActivities> groupedVenueCollection = getTrustActivitiesFromStorage
        .GroupBy(customer => new { customer.venueId, customer.venueName });
    foreach (var activity in groupedVenueCollection)
    {
        filteredVenues.Add(new TrustActivities 
        { 
            filterId = Convert.ToInt32(activity.Key.venueId), 
            filterName = activity.Key.venueName,
            filterCount = activity.Count()
        });
    }
