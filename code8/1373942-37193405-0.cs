    class ComparerStrings : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            //Compare by numbers after your initial F
            return int.Parse(x.Substring(1, 2)).CompareTo(y.Substring(1, 2));
        }
    }
