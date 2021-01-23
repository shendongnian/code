    using System;
    class Program
    {
        static void Main(string[] args)
        {
            TravelingSalesman ts = new TravelingSalesman();
            ts.City("Greenwich", 0.0, 0.0);
        }
    }
    public class TravelingSalesman
    {
        public void City(string name, double latitude, double longitude)
        {
            Name = name;
            Latitude = latitude;
            Longitude = longitude;
        }
        public string Name { set; get; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double GetDistanceFromPosition(double latitude, double longitude)
        {
            var R = 6371; //raduis of the earth in km
            var dLat = DegreesToRadians(latitude - Latitude);
            var dlon = DegreesToRadians(longitude - Longitude);
            var a =
                Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                Math.Cos(DegreesToRadians(Latitude)) *
                Math.Cos(DegreesToRadians(Latitude)) *
                Math.Sin(dlon / 2) * Math.Sin(dlon / 2)
                ;
            var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            var d = R * c; // distance in km
            return d;
        }
        private static double DegreesToRadians(double deg)
        {
            return deg * System.Math.PI / 180;
        }
        public byte[] ToBinaryString()
        {
            var result = new byte[6];
            return result;
        }
    }
