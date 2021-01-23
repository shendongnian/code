    public sealed class AnyObjectComparer : IEqualityComparer
    {
        public new bool Equals(object x, object y)
        {
            return object.Equals(x, y);
        }
        public int GetHashCode(object obj)
        {
            return obj.GetHashCode();
        }
    }
    public sealed class ChildFirstComparer : IEqualityComparer
    {
        public new bool Equals(object x, object y)
        {
            var value = x as ChildFirst;
            var other = y as ChildFirst;
            if (value == null || other == null)
                return false;
            return value.SomeIntProp1    == other.SomeIntProp1
                && value.SomeStringProp1 == other.SomeStringProp1;
        }
        public int GetHashCode(object obj)
        {
            return obj.GetHashCode();
        }
    }
    public sealed class ChildSecondComparer : IEqualityComparer
    {
        public new bool Equals(object x, object y)
        {
            var value = x as ChildSecond;
            var other = y as ChildSecond;
            if (value == null || other == null)
                return false;
            return value.SomeIntProp1    == other.SomeIntProp1
                && value.SomeStringProp1 == other.SomeStringProp1;
        }
        public int GetHashCode(object obj)
        {
            return obj.GetHashCode();
        }
    }
