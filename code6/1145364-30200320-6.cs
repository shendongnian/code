    public static IOrderedEnumerable<A> Decompose(A myValue)
    {
        SortedList<int, A> mySortedList = RecursivelyBuildMySortedList(myValue);        
        return mySortedList.AsOrderedEnumerable();
    }
