    public class KeyValuePairConverter : ConverterBase
    {
        private String _KeyName;
 
        public KeyValuePairConverter(String keyName)
        {
            // needs a parameter to get the export correct
            _KeyName = keyName;
        }
        public override object StringToField(string from)
        {
            // return everything after the last equals
            // (you could choose to validate the first part of the string against the _KeyValue)
            return from.Substring(from.LastIndexOf('=') + 1);;
        }
    
        public override string FieldToString(object fieldValue)
        {
            return String.Format("{0}={1}", _KeyName, fieldValue);
        }
    }
