    public GeoCoordinates GeosFromString(string path)
    {
        string[] lines = File.ReadAllLines(path);
        GoeCoordinates gc = new GeoCoordinates();
        gc.Latitude = Double.Parse(lines[0].Substring(4)); // this removes 'Lat:' in front of the string
        gc.Longitude = Double.Parse(lines[1].Substring(4)); // this removes 'Lon:' in front of the string
        return gc;
    }
