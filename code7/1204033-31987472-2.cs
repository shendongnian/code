    public static string MyMethod(string format)
    {
        var i = 12;
        var result = string.Format(null, format, i);
        return result;
    }
    MyMethod("{0:000}");
