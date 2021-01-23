    var yelpListingList = new List<YelpListing>();
    var businesses = yelpJsonReturned["businesses"];
    
    foreach (JsonValue business in businesses)
    {
        //parsing code goes here
    
        var location = business["location"];
        var address = location["address"];
        var coordinates = location["coordinate"];
        var listing = new YelpListing()
        {
            Id = business["id"],
            Name = business["name"],
            Address = address[0],
            City = location["city"],
            Latitude = coordinates["latitude"],
            Longitude = coordinates["longitude"],
            LocationClosed = business["is_closed"],
            MobileUrl = business["mobile_url"],
            Rating = business["rating"],
            NumberReviews = business["review_count"],
            RatingImage = business["rating_img_url_small"]
        };
        yelpListingList.Add(listing);
    }
