    public static List<Foo<T>> ToFoo<T>(this IEnumerable<T> list, IEnumerable<Qux> quxs, string quxPropName)
    {
        List<Foo<T>> foos = null;
 
        try
        {
            foos = list.Select(obj => new Foo<T>(obj, quxs, quxPropName)).ToList();
        }
        catch
        {
            foos = new List<Foo<T>>();
        }
        return foos;
    }
