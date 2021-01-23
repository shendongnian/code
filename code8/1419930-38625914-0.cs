    public enum IntervalUse
        {
            Hourly,
            Daily,
            Weekly
        }
    
        public static class EnumExt
        {
            public static string GetDescription(this IntervalUse item)
            {
                switch (item)
                {
                    case IntervalUse.Hourly:
                        return "Hour by hour";
                    case IntervalUse.Daily:
                        return "Day by day";
                    case IntervalUse.Weekly:
                        return "Each week ...";
                    default:
                        throw new ArgumentOutOfRangeException(nameof(item), item, null);
                }
            }
        }
