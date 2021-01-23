    public class DataContainer
    {
        private Dictionary<int, DataValue> _dataValues = new Dictionary<int, DataValue>();
        public DataValue this[int i] {
            get { return _dataValues[i]; }
            set { _dataValues[i] = value; }
        }
        public void Add(int index, DataValue val)
        {
            if (_dataValues.ContainsKey(index)) {
                _dataValues[index].Add(val);
            }
            else {
                _dataValues.Add(index, val);
            }
        }
    }
    public class DataValue
    {
        private Dictionary<string, List<int>> _integerValues = new Dictionary<string, List<int>>();
        private string _name { get; set; }
        private List<int> _vals { get; set; }
        public List<int> this[string i] {
            get { return _integerValues[i]; }
            set { _integerValues[i] = value; }
        }
        public DataValue(string name, params int[] val)
        {
            _name = name;
            _vals = val.ToList();
            _integerValues.Add(_name, _vals);
        }
        public void Add(string index, List<int> val)
        {
            _integerValues.Add(index, val);
        }
        public void Add(string index, params int[] val)
        {
            _integerValues.Add(index, val.ToList());
        }
        public void Add(DataValue dataValue)
        {
            _integerValues.Add(dataValue._name, dataValue._vals);
        }
    }
