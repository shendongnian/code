    public class Coord
    {
        public int lon { get; set; }
        public int lat { get; set; }
    }
    
    public class Sys
    {
        public string country { get; set; }
        public int sunrise { get; set; }
        public int sunset { get; set; }
    }
    public class Weather
    {
        public int id { get; set; }
        public string main { get; set; }
        public string description { get; set; }
        public string icon { get; set; }
    }
    public class Main
    {
        public double temp { get; set; }
        public int humidity { get; set; }
        public int pressure { get; set; }
        public double temp_min { get; set; }
        public double temp_max { get; set; }
    }
    public class Wind
    {
        public double speed { get; set; }
        public double deg { get; set; }
    }
    public class Rain
    {
        public int __invalid_name__3h { get; set; }
    }
    public class Clouds
    {
        public int all { get; set; }
    }
    public class RootObject
    {
        public Coord coord { get; set; }
        public Sys sys { get; set; }
        public List<Weather> weather { get; set; }
        public Main main { get; set; }
        public Wind wind { get; set; }
        public Rain rain { get; set; }
        public Clouds clouds { get; set; }
        public int dt { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public int cod { get; set; }
    }    
