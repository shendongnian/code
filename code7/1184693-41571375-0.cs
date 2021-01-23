    public class Foo
    {
        [BsonElement("Text"), BsonRequired]
        private string _text;
    
        [BsonIgnore]
        public string Text
        {
            get { return _text; }
            set
            {
                _text = value;
                Bar(_text);
            }
        }
        private void Bar(string text)
        {
            //Only relevant when Text is set by the user of the class,
            //not during deserialization
        }
    }
