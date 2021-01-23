    public class Foo
    {
        internal FooPropertiesListener PropertiesListener;
        private string _text;
        [BsonElement("text"), BsonRequired]
        public string Text
        {
            get { return _text; }
            set
            {
                _text = value;
                if (PropertiesListener != null)
                {
                    PropertiesListener.Bar(_text);
                }
            }
        }
    }
