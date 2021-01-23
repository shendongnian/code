    public class Foo : IEnumerable<Bar>, IEnumerable
    {
        public IEnumerator<Bar> GetEnumerator() { return null; }
        // IEnumerator GetEnumerator() { return null; } // IMPOSSIBLE
        IEnumerator IEnumerable.GetEnumerator() { return null; }
    }
