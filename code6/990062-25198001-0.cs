    public static double GetTotalDistance(IEnumerable<GeoCoordinate> coordinates)
    {
        double result = 0;
        if (coordinates.Count() > 1)
        {
            GeoCoordinate previous = coordinates.First();
            foreach (var current in coordinates)
            {
                result += previous.GetDistanceTo(current);
            }
        }
        return result;
    }
