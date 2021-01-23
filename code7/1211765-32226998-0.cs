    public void meth()
    {
        var value = GetType().GetField(varName).GetValue(this);
        Trace.WriteLine(value); // "some value"
    }
