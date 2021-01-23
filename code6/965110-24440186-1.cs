    private string address;
    public string Address {
        get {return address;}
        set {
            // Prepare the location
            GeoCoordinate loc = GetGeoCoordinateFromAddress(value);
            // Store address for future reference
            address = value;
            // Setting the location by going through the property triggers the setter
            Location = loc;
        }
    }
