    public class StationDTO
    {
        public int Id { get; set; }
        public double Lon { get; set; }
        public double Lat { get; set; }
        public int Bikes { get; set; }
        public int Slots { get; set; }
        public string Address { get; set; }
        public string NearbyStations { get; set; }
        public string Status { get; set; }
        public string Name { get; set; }
    }
...
    public class Station : StationDTO
    {
        public List<string> NearbyStationsList
        { 
            get 
            {
                return NearbyStations.Split(',');
            }
            set
            {
                NearbyStations = string.Join(",", value);
            }
        }
    }
