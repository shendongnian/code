        public static class ObjectExtensions
        {
            public static IEnumerable<object> Members(this object obj)
            {
                if (obj == null)
                    return new object[0];
                var type = obj.GetType();
                return type.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.GetIndexParameters().Length == 0 && p.GetGetMethod(true) != null && p.CanRead)
                    .Select(p => p.GetValue(obj, new object[0]))
                    .Concat(type.GetFields().Select(f => f.GetValue(obj)));
            }
            public static bool IsDefault(this object obj)
            {
                if (obj == null)
                    return true;
                var type = obj.GetType();
                if (type.IsValueType)
                {
                    return obj.Equals(Activator.CreateInstance(type, true));
                }
                return false;
            }
            public static bool MembersAreDefault(this object obj)
            {
                return obj.Members().All(v => v.IsDefault());
            }
        }
    Then modify `Customer` as follows:
        public class Customer
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            [XmlIgnore]
            public Address Address { get; set; }
            [XmlElement("Address")]
            [Browsable(false), EditorBrowsable(EditorBrowsableState.Never), DebuggerBrowsable(DebuggerBrowsableState.Never)]
            public Address SerializableAddress
            {
                get
                {
                    return Address;
                }
                set
                {
                    if (value != null && value.MembersAreDefault())
                        value = null;
                    Address = value;
                }
            }
        }
    The property `SerializableAddress` checks using reflection to see whether the incoming `Address` has any non-default values.  If not, the underlying property is set to null.  
    This solution is robust and reusable, but since it uses reflection, performance may not be great.
