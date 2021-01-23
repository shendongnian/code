    public class Range
    {
        //We store all the ranges we have
        private static List<int> ranges = new List<int>();
        public int value { get; set; }
        public static void CreateRange(int RangeStart, int RangeStop)
        {
            ranges.Add(RangeStart);
            ranges.Sort();
        }
        public Range(int value)
        {
            int previous = ranges[0];
            //Here we will find the range and give it the low boundary
            //This is a very simple foreach loop but you can make it better
            foreach (int item in ranges)
            {
                if (item > value)
                {
                    break;
                }
                previous = item;
            }
            this.value = previous;
        }
        public override int GetHashCode()
        {
            return value;
        }
    }
