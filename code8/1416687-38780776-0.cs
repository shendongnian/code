    public static class RangeFilterParse
    {
        public static Filter<T> Parse<T>(string value)
        {
            // parse the stuff!
            return new RangeFilter<T>();
        }
    }
    public abstract class Filter<T> { }
    public class RangeFilter<T> : Filter<T> { }
