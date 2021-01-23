    public abstract class ValueObject<T> : IEquatable<T> where T : ValueObject<T>
    {
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            var other = obj as T;
            return Equals(other);
        }
        public override int GetHashCode()
        {
            var fields = GetFields();
            const int startValue = 17;
            const int multiplier = 59;
            return fields
                .Select(field => field.GetValue(this))
                .Where(value => value != null)
                .Aggregate(startValue, (current, value) => current * multiplier + value.GetHashCode());
        }
        public virtual bool Equals(T other)
        {
            if (other == null)
                return false;
            var t = GetType();
            var otherType = other.GetType();
            if (t != otherType)
                return false;
            var fields = t.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
            foreach (var field in fields)
            {
                var value1 = field.GetValue(other);
                var value2 = field.GetValue(this);
                if (value1 == null)
                {
                    if (value2 != null)
                        return false;
                }
                else if (!value1.Equals(value2))
                    return false;
            }
            return true;
        }
        private IEnumerable<FieldInfo> GetFields()
        {
            var t = GetType();
            t.ForNull("this");
            var fields = new List<FieldInfo>();
            while (t != typeof(object))
            {
                if (t == null) continue;
                fields.AddRange(t.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public));
                t = t.BaseType;
            }
            return fields;
        }
        public static bool operator ==(ValueObject<T> firstInCompare, ValueObject<T> secondInCompare)
        {
            firstInCompare.ForNull(nameof(firstInCompare));
            secondInCompare.ForNull(nameof(secondInCompare));
            return firstInCompare?.Equals(secondInCompare) ?? false;
        }
        public static bool operator !=(ValueObject<T> firstInCompare, ValueObject<T> secondInCompare)
        {
            return !(firstInCompare == secondInCompare);
        }
    }
