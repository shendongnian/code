    struct Foo
    {
        public int value;
        public uint uvalue;
        public static explicit operator Foo(int val)
        {
            return new Foo { value = val };
        }
        public static explicit operator Foo(uint val)
        {
            return new Foo { uvalue = val };
        }
    }
