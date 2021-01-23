    public class Station
    {
        public int Id { get; set; }
        public double Lon { get; set; }
        public double Lat { get; set; }
        public int Bikes { get; set; }
        public int Slots { get; set; }
        public string Address { get; set; }
        [JsonConverter(typeof(StringToIntEnumerable))]
        public IEnumerable<int> NearbyStations { get; set; }  // or List<int> or int[] if 
                                                              // you prefer, just make 
                                                              // sure the convert returns 
                                                              // the same type
        public string Status { get; set; }
        public string Name { get; set; }
    }
