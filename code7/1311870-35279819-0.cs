    double? GetLondonTime(A a)
    {
        //Some logic
    }
    double? GetDelhiTime(A a)
    {
        //Some logic
    }
    void foo(A a)
    {
        If(some condition for Delhi)
            return GetDelhiTime(a);
        If(some condition for London)
            return GetLondonTime(a);
        return 0;
    }
