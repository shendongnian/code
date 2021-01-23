    public class Coord
    {
        public double lon { get; set; }
        public double lat { get; set; }
    }
    public class City
    {
        public int _id { get; set; }
        public string name { get; set; }
        public string country { get; set; }
        public Coord coord { get; set; }
    }
    public class RootObject
    {
        public IList<City> cities { get; set; }
    }
    //get the lines from the file.
    var lines = System.IO.File.ReadAllLines("list_city.json");
    //format the lines into a proper JSON array
    string json = string.Format("{cities:[{0}]}", string.Join(",", lines));
    var result = JsonConvert.DeserializeObject<Rootobject>(json);
