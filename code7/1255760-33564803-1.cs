    public void AddPushpinToTheMap(double longitude, double latitude)
    {
        var pin = new Pushpin();
        pin.Location = new Location(latitude, longitude);
        MapElements.Add(pin);
    }
