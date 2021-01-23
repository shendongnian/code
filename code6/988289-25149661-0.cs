    public static class Extensions
    {
        public static bool HasProperty(this object d, string propertyName)
        {
            return d.GetType().GetProperty(propertyName) != null;
        }
    }
