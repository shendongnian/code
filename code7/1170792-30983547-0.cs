    public partial class Taxi
        {
            public Taxi()
            {
            }
            public int TaxiId { get; set; }
            public int DriverId {get; set; }
            public virtual Driver Driver { get; set; }
            public string Make { get; set; }
            public string Model { get; set; }
            public Color Colour { get; set; }
            public string NumPlate { get; set; }
            public int MaxPassengers { get; set; }
    }
