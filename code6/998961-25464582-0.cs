            public class Row
        {
            public Row(Dictionary<string, object> data)
            {
                this._data = data;
            }
            private Dictionary<string, object> _data = new Dictionary<string, object>();
            public object this[string index]
            {
                get { return _data[index]; }
                set { _data[index] = value; }
            }
        }
