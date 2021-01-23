    public static class ExtensionMethods
    {
        [Pure]
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
        public static int BinarySearch<T>(IList<T> list, T value)
        {
            if (list == null)
                throw new ArgumentNullException("list");
            Contract.Ensures((Contract.Result<int>() >= 0) && Contract.Result<int>() <= (list.Count > 0 ? list.Count - 1 : 0) || (Contract.Result<int>() < 0 && ~Contract.Result<int>() <= list.Count));
            Contract.EndContractBlock();
            return BinarySearch(list, 0, list.Count, value, null);
        }
        [Pure]
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
        public static int BinarySearch<T>(IList<T> list, T value, IComparer<T> comparer)
        {
            if (list == null)
                throw new ArgumentNullException("list");
            Contract.EndContractBlock();
            return BinarySearch(list, 0, list.Count, value, comparer);
        }
        [Pure]
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
        public static int BinarySearch<T>(IList<T> list, int index, int length, T value, IComparer<T> comparer)
        {
            if (list == null)
                throw new ArgumentNullException("list");
            Contract.EndContractBlock();
            //Try one of the existing implementations of BinarySearch before we do our own.
            var asListT = list as List<T>;
            if (asListT != null)
                return BinarySearch(list, index, length, value, comparer);
            var asTypedArray = list as T[];
            if (asTypedArray != null)
                Array.BinarySearch<T>(asTypedArray, index, length, value, comparer);
            var asUntypedArray = list as Array;
            if (asUntypedArray != null)
            {
                if (comparer != null)
                {
                    IComparer nonGenericComparer = comparer as IComparer ?? new ComparerWrapper<T>(comparer);
                    return Array.BinarySearch(asUntypedArray, index, length, value, nonGenericComparer);
                }
                else
                {
                    return Array.BinarySearch(asUntypedArray, index, length, value, null);
                }
            }
            if (index < 0 || length < 0)
                throw new ArgumentOutOfRangeException((index < 0 ? "index" : "length"), "argument is less than 0.");
            if (list.Count - index < length)
                throw new ArgumentException("index and length do not specify a valid range in the list.");
            if (comparer == null) 
                comparer = Comparer<T>.Default;
            
            int lo = index;
            int hi = index + length - 1;
            while (lo <= hi)
            {
                // i might overflow if lo and hi are both large positive numbers. 
                int i = GetMedian(lo, hi);
                int c;
                try
                {
                    c = comparer.Compare(list[i], value);
                }
                catch (Exception e)
                {
                    throw new InvalidOperationException("Comparer failed", e);
                }
                if (c == 0) return i;
                if (c < 0)
                {
                    lo = i + 1;
                }
                else
                {
                    hi = i - 1;
                }
            }
            return ~lo;
        }
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
        private static int GetMedian(int low, int hi)
        {
            // Note both may be negative, if we are dealing with arrays w/ negative lower bounds.
            Contract.Requires(low <= hi);
            Contract.Assert(hi - low >= 0, "Length overflow!");
            return low + ((hi - low) >> 1);
        }
    }
    class ComparerWrapper<T> : IComparer
    {
        private readonly IComparer<T> _comparer;
        public ComparerWrapper(IComparer<T> comparer)
        {
            _comparer = comparer;
        }
        public int Compare(object x, object y)
        {
            return _comparer.Compare((T)x, (T)y);
        }
    }
