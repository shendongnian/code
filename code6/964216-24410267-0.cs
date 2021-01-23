    public static double Foo(object obj)
    {
        // you could include a check (IsValueType, or whatever) like you have now,
        // but it's not generally necessary, and rejects things like valid strings
        return Convert.ToDouble(obj);
    }
