    public class Foo {
        private int i;
        public int I {
            get { return i ^ -1; }
            set { i = value ^ -1; }
        }
    }
