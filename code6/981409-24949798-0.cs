    public struct RangeWithTie<T> where T : IEquatable<T>, IComparable<T>
    {
        readonly T min;
        readonly T max;
        readonly T tie;
        readonly bool isNonEmpty;
        public static Range<T> Empty = new Range<T>();
        public static IComparer<RangeWithTie<T>> CreateSortingComparer()
        {
            return new RangeWithTieComparer();
        }
        public RangeWithTie(T start, T tie, T end)
        {
            // Enfore start <= tie <= end
            var comparer = Comparer<T>.Default;
            if (comparer.Compare(start, end) > 0) // if start > end
            {
                throw new ArgumentOutOfRangeException("start and end are reversed");
            }
            else if (comparer.Compare(start, tie) > 0)
            {
                throw new ArgumentOutOfRangeException("tie is less than start");
            }
            else if (comparer.Compare(tie, end) > 0)
            {
                throw new ArgumentOutOfRangeException("tie is bigger than end");
            }
            else
            {
                this.min = start;
                this.max = end;
                this.tie = tie;
            }
            this.isNonEmpty = true;
        }
        public T Min { get { return min; } }
        public T Max { get { return max; } }
        public T Tie { get { return tie; } }
        public bool IsEmpty { get { return !isNonEmpty; } }
        public class RangeWithTieComparer : IComparer<RangeWithTie<T>>
        {
            #region IComparer<RangeWithTie<T>> Members
            public int Compare(RangeWithTie<T> x, RangeWithTie<T> y)
            {
                // return x - y.
                if (x.IsEmpty)
                {
                    if (y.IsEmpty)
                        return 0;
                    else
                        return -1;
                }
                else if (y.IsEmpty)
                {
                    return 1;
                }
                var comparer = Comparer<T>.Default;
                if (comparer.Compare(y.Min, x.Max) > 0)
                    return -1;
                else if (comparer.Compare(x.Min, y.Max) > 0)
                    return 1;
                return comparer.Compare(x.Tie, y.Tie);
            }
            #endregion
        }
        public override string ToString()
        {
            if (IsEmpty)
                return "Empty";
            StringBuilder s = new StringBuilder();
            s.Append('[');
            if (Min != null)
            {
                s.Append(Min.ToString());
            }
            s.Append(", ");
            if (Tie != null)
            {
                s.Append(Tie.ToString());
            }
            s.Append(", ");
            if (Max != null)
            {
                s.Append(Max.ToString());
            }
            s.Append(']');
            return s.ToString();
        }
    }
