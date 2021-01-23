    public class DataComparer : Comparer<Data>
    {
        private readonly IList<PropertyInfo> _sortedProperties;
        public DataComparer(IEnumerable<PropertyInfo> sortedProperties)
        {
            _sortedProperties = new List<PropertyInfo>(sortedProperties);
        }
        public override int Compare(Data x, Data y)
        {
            int result = 0;
            foreach (var property in _sortedProperties)
            {
                if (property.Name == "Name")
                {
                    result = String.Compare(x.Name, y.Name, StringComparison.Ordinal);
                }
                else if (property.Name == "Age")
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
