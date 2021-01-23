    public List<MyClass> MyMethod(List<MyClass> ListA, List<MyClass> ListB)
    {
        return (ListA.Union(ListB)).GroupBy(x=>x.ID)
                                   .Select(gr=>new MyClass { 
                                       ID=gr.Key, 
                                       Name=gr.Select(x=>x.Name).First()})
                                   .ToLIst();
    }
