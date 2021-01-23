    var foo = new Foo() { "a", "b", "c" };
    foo.Bar = "baz";
    foo.Beer = "beer";
    
    var json = GetJsonWithItemsAndProperties(foo);
    //{"0":"a","1":"b","2":"c","length":3,"Bar":"baz","Beer":"beer"}
    
    //...//
    
    private static string GetJsonWithItemsAndProperties<T>(IReadOnlyCollection<T> listWithProperties)
    {
        var data = listWithProperties
            .Select((value, index) => new {value, index})
            .ToDictionary(wrapper => wrapper.index.ToString(), wrapper => (object) wrapper.value);
    
        data.Add("length", data.Count);
    
        listWithProperties.GetType()
            .GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance |
                            System.Reflection.BindingFlags.DeclaredOnly).ToList()
            .ForEach(p => data.Add(p.Name, p.GetValue(listWithProperties)));
    
        return JsonConvert.SerializeObject(data);
    }
