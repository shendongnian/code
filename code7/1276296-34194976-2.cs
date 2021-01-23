                            // First we split by "),(" to get each of the points
    var res = locationPoints.Splits(new[]{"),("})
                            // Each point-string will be handled to produce Lat and Lng
                            .Select(pt =>
                                   {
                                       // Remove '(' and ')' to clean first/last points
                                       // And split by comma to get the two components
                                       var s = pt.Trim('()').Split(',');
                                       var lat = s[0].Trim();
                                       var lng = s[1].Trim();
                                       // Choose how to represent each point, example:
                                       return new LatLng {Lat=lat, Lng=lng};
                                   })
                            // Make an array out of that
                            .ToArray();
