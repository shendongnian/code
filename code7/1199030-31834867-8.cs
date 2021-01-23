    public T GetRandom<T>()
    {
        Type tType = typeof(T);
        IRandomTypeBuilder typeGenerator = null;
        if (tType == typeof(double))
            typeGenerator = new DoubleRandomBuilder();
        else if (tType == typeof(int))
            typeGenerator = new IntRandomBuilder();
        else if (tType == typeof(string))
            typeGenerator = new StringRandomBuilder();
        else if (tType == typeof(bool))
            typeGenerator = new BoolRandomBuilder();
        return (T)(typeGenerator == null ? default(T) : typeGenerator.GetNext());
    }
