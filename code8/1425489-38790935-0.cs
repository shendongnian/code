    public class Three {
        public One One { get; set; }
        public Two Two { get; set; }
        public class Three(One one, Two two) {
            this.One = one;
            this.Two = two;
        }
        public double MethodClassForOne() {
            return (One.item1 * One.item2);
        }
        public double MethodClassForTwo() {
            return (Two.item1 * Two.item2);
        }
        public double MethodClassOneAndTwo()
        {
            return (MethodClassForOne() * MethodClassForTwo());
        }
    }
