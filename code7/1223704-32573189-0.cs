    class SimplePoint
        {
            public SimplePoint(string coord)
            {
                var coords = coord.Split(',').Select(s => double.Parse(s, System.Globalization.CultureInfo.InvariantCulture)).ToArray();
                X = coords[0];
                Y = coords[1];
            }
            public double X;
            public double Y;
            public override string ToString()
            {
                return X.ToString() + "," + Y.ToString();
            }
        }
    static class LongLatParseAndSort
    {
        public static string SortedLongLat(string unsorted)
        {
            return unsorted
                .Split(' ')
                .Select(c => new SimplePoint(c))
                .OrderByDescending(sp => sp.X)
                .Select(sp => sp.ToString())
                .Aggregate((a, b) => a += b);
        }
    }
