    public class Foo
    {
    }
    public class Bar
    {
        Bar()
        {
            IFinder finder = // Create finder.
            // This fails because <T> (Foo) does not implement IFinder.
            IEnumerable<Foo> fooItems = finder.GetItems<Foo>();
        }
    }
