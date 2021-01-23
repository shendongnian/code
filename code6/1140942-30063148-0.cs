    public class Foo
    {
        public static List<WeakReference<Foo>> allInstances = new List<WeakReference<Foo>>();
        public Foo()
        {
            allInstances.Add(new WeakReference<Foo>(this));
        }
    }
