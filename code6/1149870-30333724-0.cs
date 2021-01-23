    public class DataRowComparer : IEqualityComparer<DataRow>
    {
        public bool Equals(DataRow x, DataRow y)
        {
            var cols = x.Table.Columns.Count;
            for (var i = 0; i < cols; i++)
            {
                if (Convert.ToString(x[i]) != Convert.ToString(y[i]))
                {
                    return false;
                }
            }
            return true;
        }
        public int GetHashCode(DataRow obj)
        {
            var hashCode = -1;
            var cols = obj.Table.Columns.Count;
            for (var i = 0; i < cols; i++)
            {
                if (hashCode == -1)
                {
                    hashCode = obj[i].GetHashCode();
                }
                else
                {
                    hashCode = hashCode ^ obj[i].GetHashCode();
                }
            }
            return hashCode;
        }
    }
