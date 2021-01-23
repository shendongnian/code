    public class MultiIntEnum<TRawType, TEnum1, TEnum2>
        where TEnum1 : struct
        where TEnum2 : struct
    {
        public TRawType Value { get; private set; }
        private MultiIntEnum() {}
        public static implicit operator MultiIntEnum<TRawType, TEnum1, TEnum2>(TEnum1 value) { return new MultiIntEnum<TRawType, TEnum1, TEnum2>() {Value = (TRawType) (object) value}; }
        public static implicit operator MultiIntEnum<TRawType, TEnum1, TEnum2>(TEnum2 value) { return new MultiIntEnum<TRawType, TEnum1, TEnum2>() {Value = (TRawType) (object) value}; }
    }
    public class MultiIntEnum<TRawType, TEnum1, TEnum2, TEnum3>
        where TEnum1 : struct
        where TEnum2 : struct
        where TEnum3 : struct
    {
        public TRawType Value { get; private set; }
        private MultiIntEnum() {}
        public static implicit operator MultiIntEnum<TRawType, TEnum1, TEnum2, TEnum3>(TEnum1 value) { return new MultiIntEnum<TRawType, TEnum1, TEnum2, TEnum3>() {Value = (TRawType) (object) value}; }
        public static implicit operator MultiIntEnum<TRawType, TEnum1, TEnum2, TEnum3>(TEnum2 value) { return new MultiIntEnum<TRawType, TEnum1, TEnum2, TEnum3>() {Value = (TRawType) (object) value}; }
        public static implicit operator MultiIntEnum<TRawType, TEnum1, TEnum2, TEnum3>(TEnum3 value) { return new MultiIntEnum<TRawType, TEnum1, TEnum2, TEnum3>() {Value = (TRawType) (object) value}; }
    }
    public class MultiIntEnum<TRawType, TEnum1, TEnum2, TEnum3, TEnum4>
        where TEnum1 : struct
        where TEnum2 : struct
        where TEnum3 : struct
        where TEnum4 : struct
    {
        public TRawType Value { get; private set; }
        private MultiIntEnum() {}
        public static implicit operator MultiIntEnum<TRawType, TEnum1, TEnum2, TEnum3, TEnum4>(TEnum1 value) { return new MultiIntEnum<TRawType, TEnum1, TEnum2, TEnum3, TEnum4>() {Value = (TRawType) (object) value}; }
        public static implicit operator MultiIntEnum<TRawType, TEnum1, TEnum2, TEnum3, TEnum4>(TEnum2 value) { return new MultiIntEnum<TRawType, TEnum1, TEnum2, TEnum3, TEnum4>() {Value = (TRawType) (object) value}; }
        public static implicit operator MultiIntEnum<TRawType, TEnum1, TEnum2, TEnum3, TEnum4>(TEnum3 value) { return new MultiIntEnum<TRawType, TEnum1, TEnum2, TEnum3, TEnum4>() {Value = (TRawType) (object) value}; }
        public static implicit operator MultiIntEnum<TRawType, TEnum1, TEnum2, TEnum3, TEnum4>(TEnum4 value) { return new MultiIntEnum<TRawType, TEnum1, TEnum2, TEnum3, TEnum4>() {Value = (TRawType) (object) value}; }
    }
    public class MultiIntEnum<TRawType, TEnum1, TEnum2, TEnum3, TEnum4, TEnum5>
        where TEnum1 : struct
        where TEnum2 : struct
        where TEnum3 : struct
        where TEnum4 : struct
        where TEnum5 : struct
    {
        public TRawType Value { get; private set; }
        private MultiIntEnum() {}
        public static implicit operator MultiIntEnum<TRawType, TEnum1, TEnum2, TEnum3, TEnum4, TEnum5>(TEnum1 value) { return new MultiIntEnum<TRawType, TEnum1, TEnum2, TEnum3, TEnum4, TEnum5>() {Value = (TRawType) (object) value}; }
        public static implicit operator MultiIntEnum<TRawType, TEnum1, TEnum2, TEnum3, TEnum4, TEnum5>(TEnum2 value) { return new MultiIntEnum<TRawType, TEnum1, TEnum2, TEnum3, TEnum4, TEnum5>() {Value = (TRawType) (object) value}; }
        public static implicit operator MultiIntEnum<TRawType, TEnum1, TEnum2, TEnum3, TEnum4, TEnum5>(TEnum3 value) { return new MultiIntEnum<TRawType, TEnum1, TEnum2, TEnum3, TEnum4, TEnum5>() {Value = (TRawType) (object) value}; }
        public static implicit operator MultiIntEnum<TRawType, TEnum1, TEnum2, TEnum3, TEnum4, TEnum5>(TEnum4 value) { return new MultiIntEnum<TRawType, TEnum1, TEnum2, TEnum3, TEnum4, TEnum5>() {Value = (TRawType) (object) value}; }
        public static implicit operator MultiIntEnum<TRawType, TEnum1, TEnum2, TEnum3, TEnum4, TEnum5>(TEnum5 value) { return new MultiIntEnum<TRawType, TEnum1, TEnum2, TEnum3, TEnum4, TEnum5>() {Value = (TRawType) (object) value}; }
    }
