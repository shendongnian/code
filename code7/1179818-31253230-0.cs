    public class Foo
    {
        [XmlIgnore]
        public MyEnum myEnum { get; set; }
        [XmlElement("Bar")]
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never), DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public XmlEnumWrapper<MyEnum> myEnumXml { get { return myEnum; } set { myEnum = value; } }
    }
    public struct XmlEnumWrapper<TEnum> : IEquatable<XmlEnumWrapper<TEnum>> where TEnum : struct, IConvertible, IComparable, IFormattable
    {
        TEnum value;
        public XmlEnumWrapper(TEnum value)
        {
            this.value = value;
        }
        public static implicit operator TEnum(XmlEnumWrapper<TEnum> wrapper)
        {
            return wrapper.Value;
        }
        public static implicit operator XmlEnumWrapper<TEnum>(TEnum anEnum)
        {
            return new XmlEnumWrapper<TEnum>(anEnum);
        }
        public static bool operator ==(XmlEnumWrapper<TEnum> first, XmlEnumWrapper<TEnum> second)
        {
            return first.Equals(second);
        }
        public static bool operator !=(XmlEnumWrapper<TEnum> first, XmlEnumWrapper<TEnum> second)
        {
            return !first.Equals(second);
        }
        [XmlIgnore]
        public TEnum Value { get { return value; } private set { this.value = value; } }
        [XmlText]
        public string ValueString
        {
            get
            {
                return Value.ToString();
            }
            set
            {
                // See here if one needs to parse XmlEnumAttribute attributes
                // http://stackoverflow.com/questions/3047125/retrieve-enum-value-based-on-xmlenumattribute-name-value
                value = value.Trim();
                Value = (TEnum)Enum.Parse(typeof(TEnum), value, false);
            }
        }
        #region IEquatable<XmlEnumWrapper<TEnum>> Members
        public bool Equals(XmlEnumWrapper<TEnum> other)
        {
            return EqualityComparer<TEnum>.Default.Equals(Value, other.Value);
        }
        #endregion
        public override bool Equals(object obj)
        {
            if (obj is XmlEnumWrapper<TEnum>)
                return Equals((XmlEnumWrapper<TEnum>)obj);
            return Value.Equals(obj);
        }
        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }
        public override string ToString()
        {
            return Value.ToString();
        }
    }
