    class c2: c1 {
        public void fn2(int? value) {
            Console.WriteLine("value {0} is nullable", value);
        }
        public new void fn2(int value) {
            base.fn2(value);
        }
    }
