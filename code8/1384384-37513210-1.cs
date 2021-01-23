    public class KeyComparer : Comparer<Key>
    {
        public override int Compare(Key x, Key y)
        {
            return Comparer.Default<string>.Compare(x.otherSortingVariable, y.otherSortingVariable);
        }
    }
