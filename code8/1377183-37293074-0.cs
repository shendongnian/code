    class MockDataReader : IDataReader
    {
        private List<object[]> _data;
        private int _current = -1;
        public MockDataReader(List<object[]> data)
        {
            _data = data;
        }
        public int FieldCount
        {
            get
            {
                return _data.FirstOrDefault()?.Length ?? 0;
            }
        }
        public int GetValues(object[] values)
        {
            object[] record = _data[_current];
            for (int i = 0; i < record.Length; i++)
            {
                values[i] = record[i];
            }
            return record.Length;
        }
        public bool Read()
        {
            _current++;
            return _current < _data.Count;
        }
    }
