    public class Item
    {
        TypeCode _type = TypeCode.Empty; // When deserializing, attributes are deserialized before element values, which allows the _type to be set before the XmlValue is read.
        IConvertible _value = null;
        static TypeCode GetItemType(IConvertible value)
        {
            if (value == null)
                return TypeCode.Empty;
            return value.GetTypeCode();
        }
        [XmlAttribute("type")]
        public TypeCode type
        {
            get
            {
                return _type;
            }
            set
            {
                _type = value;
                if (GetItemType(_value) != _type)
                    _value = null;
            }
        }
        [XmlAttribute("key")]
        public string key { get; set; }
        [XmlIgnore]
        public IConvertible Value
        {
            get
            {
                return _value;
            }
            set
            {
                _type = GetItemType(value);
                _value = value;
            }
        }
        [XmlText]
        public string XmlValue
        {
            get
            {
                if (_value == null)
                    return null;
                return Value.ToString(CultureInfo.InvariantCulture);
            }
            set
            {
                if (value == null)
                    _value = null;
                else
                {
                    _value = (IConvertible)Convert.ChangeType(value, _type, CultureInfo.InvariantCulture);
                }
            }
        }
    }
