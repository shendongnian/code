    public class Class1
    {
    }
    public class Class2 : Class1
    {
    }
    private void TestType()
    {
        var collection = new List<Class1>();
        collection.Add(new Class1());
        collection.Add(new Class2());
        var results = new List<Class1>();
        foreach (var item in collection)
        {
            Class1 c1 = (item as Class1);   // Won't throw if not Class1
            if ( c1 != null )
            {
                results.Add(c1);
            }
        }
    }
