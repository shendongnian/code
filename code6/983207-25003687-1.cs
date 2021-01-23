    public class DataComparer : Comparer<Data>
    {
        private readonly IList<string> _sortedProperties;
        public DataComparer(IEnumerable<string> sortedProperties)
        {
            _sortedProperties = new List<string>(sortedProperties);
        }
        public override int Compare(Data x, Data y)
        {
            int result = 0;
            foreach (var property in _sortedProperties)
            {
                if (property == "Name")
                {
                    result = String.Compare(x.Name, y.Name, StringComparison.Ordinal);
                }
                else if (property == "Age")
                {
                    result = x.Age.CompareTo(y.Age);
                }
                // Do other comparisons here
                if (result != 0)
                    return result;
            }
            return 0;
        }
    }
