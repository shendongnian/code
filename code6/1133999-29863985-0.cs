    class Location : ILocation
    {
        public ICoordinates Coordinate1 { get; set; }
        public ICoordinates Coordinate2 { get; set; }
        public Location(ICoordinates c1, ICoordinates c2)
        {
            this.Coordinate1 = c1;
            this.Coordinate2 = c2;
        }
    }
