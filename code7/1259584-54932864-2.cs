    /// <summary>The Range class.</summary>
    /// <typeparam name="T">Generic parameter.</typeparam>
    public class Range<T> where T : IComparable<T>
    {
        /// <summary>Minimum value of the range.</summary>
        public T Minimum { get; set; }
        /// <summary>Maximum value of the range.</summary>
        public T Maximum { get; set; }
        public Range(T min, T max)
        {
            Minimum = min;
            Maximum = max;
        }
    }
    public static class RandomExtension
    {
        static Random random = new Random();
        public static int NextFromRanges(this Random random, List<Range<int>> ranges)
        {
            int randomRange = random.Next(0, ranges.Count);
            return random.Next(ranges[randomRange].Minimum, ranges[randomRange].Maximum);
        }
    }
