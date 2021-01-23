    public static List<SomeType> GetSomeTypeList()
    {
        if (_list == null)
        {
            var temp = FunctionToGetSomeTypeValue();
            Interlocked.CompareExchange(ref _list, temp, null);
        }
        return _list;
    }
