    public class CustomKeyValuePair
    {
        public CustomKeyValuePair(string key, string value)
        {
            this.Key = key;
            this.Value = value;
        }
        public string Key { get; set; }
        public string Value { get; set; }
        public override string ToString()
        {
            return Key;
        }
    }
    KeyValuePair<'string',KeyValuePair<'string',CustomKeyValuePair>('A', new CustomKeyValuePair('B','C'))
