    public class DataContainer
    {
        private Dictionary<int, DataValue> _dataValues = new Dictionary<int, DataValue>();
        public DataValue this[int i] {
            get { return _dataValues[i]; }
            set { _dataValues[i] = value; }
        }
        public List<int> this[string i] {
            get {
                List<List<int>> l = new List<List<int>>();
                foreach (DataValue dv in _dataValues.Values) {
                    try {
                        l.Add(dv[i]);
                    }
                    catch { }
                }
                if (l.Count > 0) {
                    List<int> result = new List<int>();
                    for (int j = 0; j < l.Count; j++){
                        for (int z = 0; z < l.FirstOrDefault().Count; z++) {
                            if (j == 0) {
                                result.Add(l[j][z]);
                            }
                            else {
                                result[z] += l[j][z];
                            }
                        }
                    }
                    return result;
                }
                return null;
            }
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
