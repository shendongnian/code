     public class Vehicle
        {
            [Key]
            public int Id { set; get; }
            ///
            // common properties
            ///
            public Car Car { set; get; }
            public Boat Boat { set; get; }
            public Plane Plane { set; get; }
        }
        public class Car
        {
            [Key, ForeignKey("Vehicle")]
            public int VehicleId { set; get; }
            public Vehicle Vehicle { set; get; }
            ///
            // Car properties
            ///
        }
        public class Boat
        {
            [Key, ForeignKey("Vehicle")]
            public int VehicleId { set; get; }
            public Vehicle Vehicle { set; get; }
            ///
            // Boat properties
            ///
        }
        public class Plane
        {
            [Key, ForeignKey("Vehicle")]
            public int VehicleId { set; get; }
            public Vehicle Vehicle { set; get; }
            ///
            // Plane properties
            ///
        }
