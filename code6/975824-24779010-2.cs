    public class Foo : IEnumerable<Bar>, IEnumerable
    {
        public IEnumerator<Bar> GetEnumerator() { return null; }
        private void test()
        {
            // relatively obvious:
            this.GetEnumerator(); // calls GetEnumerator<>() !
            ((IEnumerable)this).GetEnumerator(); // calls plain GetEnumerator()
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            // very inobvious:
            return this.GetEnumerator(); // calls GetEnumerator<> ! no recursion!!
            // ((IEnumerable)this).GetEnumerator(); // would call itself recursively
        }
    }
