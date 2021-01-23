    public enum DistanceUnit { miles, kilometers, nauticalmiles }
    public double CalculateDistance( double lat1, double lon1 , double lat2 , double lon2, DistanceUnit unit)
    {
        Func<double, double> deg2rad = deg => (deg * Math.PI / 180.0);
        Func<double, double> rad2deg = rad => (rad / Math.PI * 180.0);
        double theta = lon1 - lon2;
        double dist = Math.Sin(deg2rad(lat1)) * Math.Sin(deg2rad(lat2)) + Math.Cos(deg2rad(lat1)) * Math.Cos(deg2rad(lat2)) * Math.Cos(deg2rad(theta));
        dist = Math.Acos(dist);
        dist = rad2deg(dist);
        dist = dist * 60 * 1.1515;
        if (unit == DistanceUnit.kilometers)
        {
            dist = dist * 1.609344;
        }
        else if (unit == DistanceUnit.nauticalmiles)
        {
            dist = dist * 0.8684;
        }
        return (dist);
    }
