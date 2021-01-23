    public static class MapExtensions
    {
        private static Geopoint GetCorner(this MapControl Map, double x, double y, bool top)
        {
            Geopoint corner = null;
            try
            {
                Map.GetLocationFromOffset(new Point(x, y), out corner);
            }
            catch
            {
                Geopoint position = new Geopoint(new BasicGeoposition()
                {
                    Latitude = top ? 85 : -85,
                    Longitude = 0
                });
                Point point;
                Map.GetOffsetFromLocation(position, out point);
                Map.GetLocationFromOffset(new Point(0, point.Y), out position);
            }
            return corner;
        }
        public static Geopoint GetTopLeftCorner(this MapControl Map)
        {
            return Map.GetCorner(0, 0, true);
        }
        public static Geopoint GetBottomLeftCorner(this MapControl Map)
        {
            return Map.GetCorner(0, Map.ActualHeight, false);
        }
        public static Geopoint GetTopRightCorner(this MapControl Map)
        {
            return Map.GetCorner(Map.ActualWidth, 0, true);
        }
        public static Geopoint GetBottomRightCorner(this MapControl Map)
        {
            return Map.GetCorner(Map.ActualWidth, Map.ActualHeight, true);
        }
    }
