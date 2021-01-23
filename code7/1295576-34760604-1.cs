        public class IndexedByBoolean
        {
            public int this[bool parameter]
            {
                get { ... }
                set { ...}
            }
        }
        public class ContainsPropertyIndexedByBool
        {
            private readonly IndexedByBoolean index;
            public IndexedByBoolean NoseLo { get { return index; } }
        }
    Then you could use `foo.NoseLo[true] = 0`
