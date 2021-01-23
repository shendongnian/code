    public class Base<T> {
        public abstract T Clone()
    }
    public class Child : Base<Child> {
        public override Child Clone() {
            return ...;
        }
    }
