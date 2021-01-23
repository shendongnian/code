    public class ValueKeeper {
        private List<object> values;
        public object Value {
            get { return ToString(); }
            set { values.Add(value); }
        }
        public ValueKeeper() {
            values = new ArrayList<object>();
        }
        public override string ToString() {
            string result = String.Empty;
            foreach(object value in values) result += value.ToString();
            return result;
        }
    }
