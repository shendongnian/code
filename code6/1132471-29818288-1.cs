    public class Foo {
        private int i;
        public int I {
            get { return ~i; }
            set { i = ~value; }
        }
    }
