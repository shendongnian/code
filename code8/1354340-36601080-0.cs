        public static Point Offset(this Point point, double angle, double distanceInMeters)
        {
            double rad = Math.PI * angle / 180;
            double xRad = Math.PI * point.X / 180; // convert to radians
            double yRad = Math.PI * point.Y / 180;
            double R = 6378100; //Radius of the Earth in meters
            double x = Math.Asin(Math.Sin(xRad) * Math.Cos(distanceInMeters/ R)
                                  + Math.Cos(xRad) * Math.Sin(distanceInMeters/ R) * Math.Cos(rad));
            double y = yRad + Math.Atan2(Math.Sin(rad) * Math.Sin(distanceInMeters/ R) * Math.Cos(xRad), Math.Cos(distanceInMeters/ R) - Math.Sin(xRad) * Math.Sin(x));
            x = x * 180 / Math.PI; // convert back to degrees
            y = y * 180 / Math.PI;
            return new Point(x, y);
        }
