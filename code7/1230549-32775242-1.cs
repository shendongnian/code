    public static List<Foo> ToFoo<T>(this IEnumerable<T> objCollection, IEnumerable<Qux> quxs)
    {
        List<Foo> foos = new List<Foo>();
        foreach (T obj in objCollection)
        {
            var baz = obj as Baz;
            var bar = obj as Bar;
            Foo foo = null;
            if(baz != null)
                foo = new Foo(baz, quxs.Single(qux => qux.ID == baz.BazQux));
            if(bar != null)
                foo = new Foo(bar, quxs.Single(qux => qux.ID == bar.BarQux));
            if(foo != null)
                foos.Add(foo);
        }
        return foos;
    }
