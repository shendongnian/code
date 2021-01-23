        public class CustomDataRowComparer : IEqualityComparer<DataRow>
        {
            public bool Equals(DataRow x, DataRow y)
            {
                return x.Equals(y);
            }
            public int GetHashCode(DataRow obj)
            {
                return string.Join("^", obj.ItemArray.Select((x, i) => i == 1 ? "" : x.ToString()).ToArray()).GetHashCode();
            }
        }
