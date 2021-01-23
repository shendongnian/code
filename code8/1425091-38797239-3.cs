    public class MyEqualityComparer : IEqualityComparer<DataRow>
    {
        private readonly string[] columnNames;
        public MyEqualityComparer(string[] columnNames)
        {
            this.columnNames = columnNames;
        }
        public bool Equals(DataRow x, DataRow y)
        {
            return columnNames.All(cn => x[cn].Equals(y[cn]));
        }
        public int GetHashCode(DataRow obj)
        {
            unchecked
            {
                int hash = 19;
                foreach (var value in columnNames.Select(cn => obj[cn]))
                {
                    hash = hash * 31 + value.GetHashCode();
                }
                return hash;
            }
        }
    }
