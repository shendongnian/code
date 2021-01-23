        namespace WpfDataGrid._32635114
    {
        public class DataStore
        {
            private List<Record> _values;
            public List<Record> Values { get { return _values; } }
    
            public DataStore() {
                _values = new List<Record>();
                _values.Add(new Record() { EffectivityString = "somestring1" });
                _values.Add(new Record() { EffectivityString = "somestring2" });
                _values.Add(new Record() { EffectivityString = "somestring3" });
                _values.Add(new Record() { EffectivityString = "somestring4" });
            }
        }
    
        public class Record
        {
            public String EffectivityString { get; set; }
        }
    }
  
