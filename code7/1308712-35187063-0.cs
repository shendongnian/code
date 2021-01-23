    [XmlRoot("Root")]
    public class RootObject
    {
        [XmlElement("Type1", typeof(Type1), IsNullable = true)]
        [XmlElement("Type2", typeof(Type2), IsNullable = true)]
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never), DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public object [] TypeArray
        {
            get
            {
                if (Type == null)
                    return null;
                var collection = Type as IEnumerable;
                if (collection != null)
                    return collection.Cast<object>().ToArray();
                else
                    return new[] { Type };
            }
            set
            {
                if (value == null)
                {
                    Type = null;
                    return;
                }
                var type1 = value.OfType<Type1>().ToList();
                var type2 = value.Where(t => t == null || t is Type2).Cast<Type2>().ToList();
                if (type2.Count == 1 && type1.Count == 0)
                    Type = type2[0];
                else if (type1.Count == value.Length)
                    Type = type1;
                else
                    throw new InvalidOperationException("invalid value");
            }
        }
        [XmlIgnore]
        public object Type { get; set; }
    }
