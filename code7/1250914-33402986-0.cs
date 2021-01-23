    public class IntRange : Range<Int32>
    {
        public static List<IntRange> ParseRanges(string ranges)
        {
            return new[] { Create<IntRange, int>(1, 2) }.ToList();
        }
    }
    
    public static TRangeType Create<TRangeType, TItemType>(TItemType bound1, TItemType bound2)
     where TRangeType : Range<TItemType>, new()
     where TItemType : IComparable<TItemType>
    {
        if (bound1.CompareTo(bound2) <= 0)
        {
    		return new TRangeType { Minimum = bound1 };
        }
        else
        {
    		return new TRangeType { Minimum = bound2, Maximum=bound2 };
        }
    }
