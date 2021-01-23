    private static readonly IDictionary<string, IMemberGetter> _getters 
        = new DictionaryFactory().CreateDictionary<string, IMemberGetter>();        
    public static object GetPropertyValue(object o, string memberName)
    {
        var getter = _getters.GetOrAdd(memberName + o.GetType().FullName, x => o.GetType()
            .GetProperty(memberName).ToMemberGetter());
        return getter.GetValue(o);
    }
