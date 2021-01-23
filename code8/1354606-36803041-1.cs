    static class FluentIs {
        public static IsResult Or<T>(this IsResult prev) {
            return new IsResult(prev, (v, x) => v || (x is T));
        }
        public static IsResult Is<T>(this object target) {
            return new IsResult(target, () => target is T);
        }
        public class IsResult {
            Func<bool> value;
            object target;
            internal IsResult(IsResult r, Func<bool, object, bool> getValue) :
                this(r.target, () => getValue(r.value(), r.target)) {
            }
            internal IsResult(object target, Func<bool> value) {
                this.target = target;
                this.value = value;
            }
            public static bool operator true(IsResult r) {
                return r.value();
            }
            public static bool operator false(IsResult r) {
                return !r.value();
            }
        }
    }
