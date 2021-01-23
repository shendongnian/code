    public class StringContent : ContentBase
    {
        private string _value;
        public ContentType Type 
        {
            get { return ContentType.String; } 
            private set;
        }
        public string Value
        {
            get { return _value; }
            set { _value = (string)value; }
        }
    }
