    private bool CheckType(object o, params Type[] types)
    {
        //you can optionally check, that types are interfaces
        //and throw exceptions if non-interface type was passed
        return types.All(type => type.IsAssignableFrom(o.GetType()));
    }
	CheckType(new List<int>(), typeof(IEnumerable), typeof(IList)); //returns true
	CheckType(0, typeof(IEnumerable)); //return false
