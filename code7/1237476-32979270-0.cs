    public struct XdrTypeWrapper<T>
    {
        class XdrTypeWrapperTypeDictionary
        {
            static XdrTypeWrapperTypeDictionary instance;
            static XdrTypeWrapperTypeDictionary() { instance = new XdrTypeWrapper<T>.XdrTypeWrapperTypeDictionary(); }
            public static XdrTypeWrapperTypeDictionary Instance { get { return instance; } }
            readonly Dictionary<Type, string> dict;
            XdrTypeWrapperTypeDictionary()
            {
                // Taken from https://msdn.microsoft.com/en-us/library/ms256121.aspx
                // https://msdn.microsoft.com/en-us/library/ms256049.aspx
                // https://msdn.microsoft.com/en-us/library/ms256088.aspx
                dict = new Dictionary<Type, string>
                {
                    { typeof(string), "string" },
                    { typeof(sbyte), "i1" },
                    { typeof(byte), "u1" },
                    { typeof(short), "i2" },
                    { typeof(ushort), "u2" },
                    { typeof(int), "int" }, // Could have used i4
                    { typeof(uint), "ui4" },
                    { typeof(long), "i8" },
                    { typeof(ulong), "ui8" },
                    { typeof(DateTime), "dateTime" },
                    { typeof(bool), "boolean" },
                    { typeof(double), "float" }, // Could have used r8
                    { typeof(float), "r4" },
                };
            }
            public string DataType(Type type)
            {
                return dict[type];
            }
        }
        public XdrTypeWrapper(T value) { this.value = value; }
        public static implicit operator XdrTypeWrapper<T>(T value) { return new XdrTypeWrapper<T>(value); }
        public static implicit operator T(XdrTypeWrapper<T> wrapper) { return wrapper.Value; }
        [XmlAttribute("dt", Namespace = "urn:schemas-microsoft-com:datatypes")]
        public string DataType
        {
            get
            {
                return XdrTypeWrapperTypeDictionary.Instance.DataType(typeof(T));
            }
            set
            {
                // Do nothing.
            }
        }
        T value;
        [XmlText]
        public T Value { get { return value; } set { this.value = value; } }
    }
