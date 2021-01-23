    class MyData
    {
        private readonly int _intField;
        private readonly string _stringField;
        public MyData(int intField, string stringField)
        {
            _intField = intField;
            _stringField = stringField;
        }
        public MyData With(int? intValue = null, string stringValue = null)
        {
            return new MyData(
                intValue ?? _intField,
                stringValue ?? _stringField);
        }
        // should obviously be put into an extension-class of some sort
        public static MyData With(/*this*/ MyData from, int? intValue = null, string stringValue = null)
        {
            return from.With(intValue, stringValue);
        }
        public int IntField
        {
            get { return _intField; }
        }
        public string StringField
        {
            get { return _stringField; }
        }
    }
