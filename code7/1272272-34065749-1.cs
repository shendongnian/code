    public class Foo
    {
        private readonly int[] array; // Initialized in constructor
        private readonly IReadOnlyList<int> Wrapper { get; }
        public Foo(...)
        {
            array = ...;
            Wrapper = new ReadOnlyCollection<int>(array);
        }
    }
