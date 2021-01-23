    public static List<SomeType> GetSomeTypeList()
    {
        if (_list == null)
        {
            lock (_lock)
            {
                if (_list == null)
                {
                    _list = FunctionToGetSomeTypeValue();
                }
            }
        }
        return _list;
    }
