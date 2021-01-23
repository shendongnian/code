    Restaurant[] restaurants = null;
    using (MyEntities db = new MyEntities())
    {
        restaurants = db.restaurant
                        .Where(cl => cl.longitude > lng_min)
                        .Where(cl => cl.longitude < lng_max)
                        .Where(cl => cl.latitude > lat_min)
                        .Where(cl => cl.latitude < lat_max)
                        .Include(cl => cl.review)
                        .ToArray();
    }
    var geoLocations = restaurants
                    .Select(cl => new ObjectGeoLocationDTO
                    {
                        myObject = cl,
                        Distance = ModelDefinedFunctions.udf_Haversine(origLat, origLng, cl.latitude, cl.longitude)
                    });
    return geoLocations.Where(x => x.Distance <= 10);
