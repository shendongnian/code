    class DescendedStringComparer : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            int ascendingResult = Comparer<string>.Default.Compare(x, y);
            // turn the result around
            return 0 - ascendingResult;
        }
    }
    //
    SortedDictionary<string, string> test
         = new SortedDictionary<string, string>(new DescendedDateComparer());
