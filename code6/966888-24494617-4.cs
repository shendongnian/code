    public static class DataPointCollectionExtension
    {
        // Adds a new point to the end of the collection, with a spedified y and
        // a value of x that is dx larger than the last value.
        public static void AddDXY(this DataPointCollection points, double dx, double y)
        {
            double x = 0.0; // Default starting x if there are no points in the collection.
            if (points.Count() > 0) { x = points.Last().XValue + dx; }
            points.Add(new DataPoint(x, y));
        }
    }
