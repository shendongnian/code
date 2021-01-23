    public static class DataPointCollectionExtension
    {
        public static void AddY(this DataPointCollection points, double y, double increment)
        {
            double x = points.Last().XValue + increment;
            DataPoint dp = new DataPoint(x, y);
            points.Add(dp);
        }
    }
