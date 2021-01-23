    class LatLon : Location
    {
        //Get rid of these
        //public readonly double Latitude;
        //public readonly double Longitude;
        public LatLon(double latitude, double longitude)
              : base(latitude, longitude) //This calls the base's (double, double) constuctor.
        {
        }
        //... Everything else can stay the same
    }
    LatLon l1 = GetBinnedLocation(new LatLon(41, -51.000001));
    
    ...
    
    private LatLon GetBinnedLocation(Location loc)
    {
        return new LatLon(
            getBinnedCoord(loc.Latitude, true),
            getBinnedCoord(loc.Longitude, false));
    }
