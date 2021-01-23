    public class DataRowAdapter<T>
    {
        DataRow _dataRow;
        public DataRowAdapter(DataRow dataRow)
        {
            _dataRow = dataRow;
        }
        public DataRow Current
        {
            get
            {
                return _dataRow;
            }
        }
    }
