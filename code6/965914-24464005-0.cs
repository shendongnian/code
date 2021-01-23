    var duplicates = dataTable
            .AsEnumerable()
            .GroupBy(r => r, new MyDataRowComparer(keys))
            .Where(c => c.Count() > 1)
            .ToList();
    internal class MyDataRowComparer : IEqualityComparer<DataRow>
    {
        private readonly string[] _keys;
        public MyDataRowComparer(string[] keys)
        {
            _keys = keys; // keep the keys to compare by.
        }
        public bool Equals(DataRow x, DataRow y)
        {
            // a simple implementation that checks if all the required fields 
            // match. This might need more work.
            bool areEqual = true;
            foreach (var key in _keys)
            {
                areEqual &= (x[key] == y[key]);
            }
        }
        public int GetHashCode(DataRow obj)
        {
            // Add implementation here to create an aggregate hashcode.
        }
    }    
