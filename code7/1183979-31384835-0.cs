    public class Wgs84Point
    {
        const double MaxDegreesLongitude = 180;
        const double MinDegreesLongitude = -180;
        const double MaxDegreesLatitude = 90;
        const double MinDegreesLatitude = -90;
        readonly double _longitude;
        readonly double _latitude;
        public double Latitude { get { return _latitude; } }
        public double Longitude { get { return _longitude; } }
        public Wgs84Point(double longitude, double latitude)
        {
            if (longitude > MaxDegreesLongitude || longitude < MinDegreesLongitude)
                throw new ArgumentException("longitude");
            if (latitude > MaxDegreesLatitude || latitude < MinDegreesLatitude)
                throw new ArgumentException("latitude");
            _longitude = longitude;
            _latitude = latitude;
        }
        public Distance DistanceTo(Wgs84Point that)
        {
            if (that == null)
                throw new ArgumentNullException("that");
            if (this == that)
                return Distance.Zero;
            var dLat = DegreesToRadians(Latitude - that.Latitude);
            var dLon = DegreesToRadians(Longitude - that.Longitude);
            var a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                Math.Cos(DegreesToRadians(Latitude)) * 
                Math.Cos(DegreesToRadians(that.Latitude)) *
                Math.Sin(dLon / 2) * Math.Sin(dLon / 2);
            var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            var d = Distance.RadiusOfEarth.ToDouble() * c;
            return new Distance(d);
        }
        static double DegreesToRadians(double degrees)
        {
            return degrees * (Math.PI / 180);
        }
    }
