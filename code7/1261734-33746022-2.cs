    public class Foo {
        private int X {
            get { return 0; }
            set { }
        }
    
        public Foo(string s) {
            int.TryParse(s, out X);
        }
    }
