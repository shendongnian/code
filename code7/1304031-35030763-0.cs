    public class Row
        {
            public Row() { }
            private string _text;
            public String Text
            {
                get
                {               
                    return _text;
                }
            set
            {
                _text = value;                
            }
        }
        public override int GetHashCode()
        {
            return _text;
        }
        public bool Equals(Row r)
        {
            return r._text == _text;
        }
        public override bool Equals(object r)
        {
            Row row = r as Row;
            return row != null && row._text == _text;
        }
    }
