    public class MyFinderA : IFinder
    {
        IEnumerable<T> GetItems<T>() where T : IFinder
        {
            return // Create collection of T
    }
    public class Bar
    {
        Bar()
        {
            IFinder finder = // Create finder.
            // This works as <T> (MyFinderA) is an IFinder implementation
            IEnumerable<MyFinderA> finderItems = finder.GetItems<MyFinderA>();
        }
    }
