    private static Dictionary<Type, String> s_Search = new Dictionary<Type, String>()
    {
        {typeof(MyTypeA), "optiona"},
        {typeof(MyTypeB), "optionb"}
    }
    
    ...
    
    public XDocument DoSearch<T>()
    { 
        return searchService.Search(dictionary[s_Search(typeof(T))]);
    }
