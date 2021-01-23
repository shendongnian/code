    [System.Serializable]
    public class AddressComponent
    {
        public string long_name;
        public string short_name;
        public List<string> types;
    }
    [System.Serializable]
    public class Location
    {
        public double lat;
        public double lng;
    }
    [System.Serializable]
    public class Northeast
    {
        public double lat;
        public double lng;
    }
    [System.Serializable]
    public class Southwest
    {
        public double lat;
        public double lng;
    }
    [System.Serializable]
    public class Viewport
    {
        public Northeast northeast;
        public Southwest southwest;
    }
    [System.Serializable]
    public class Geometry
    {
        public Location location;
        public string location_type;
        public Viewport viewport;
    }
    [System.Serializable]
    public class Result
    {
        public List<AddressComponent> address_components;
        public string formatted_address;
        public Geometry geometry;
        public string place_id;
        public List<string> types;
    }
    [System.Serializable]
    public class GoogleJson
    {
        public List<Result> results;
        public string status;
    }
