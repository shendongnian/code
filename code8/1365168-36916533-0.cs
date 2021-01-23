    public static class GeometryExtensions
    {
        public static bool IsEmpty(this Geometry geometry)
        {
            var result = false;
            var expected = Geometry.Empty;
            if (geometry != null)
            {
                result = (geometry.Bounds == expected.Bounds);
            }
            return result;
        }
    }
