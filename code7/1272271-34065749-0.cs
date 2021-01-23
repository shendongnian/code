    public class Foo
    {
        private readonly int[] array; // Initialized in constructor
        public IReadOnlyList<int> Array => array.ToArray(); // Copy
        public IReadOnlyList<int> Wrapper => new ReadOnlyCollection<int>(array); // Wrap
    }
