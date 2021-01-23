    public delegate void MyDelegate(int a, int b, int? c = null, int? d = null);
    public void Method(int a, int b, int c = 10, int d = 42) { ... }
    new MyDelegate((a, b, c, d) =>
    {
        if (c.HasValue && d.HasValue)
            Method(a, b, c.Value, d.Value);
        else if (c.HasValue)
            Method(a, b, c.Value);
        else if (d.HasValue)
            Method(a, b, d: d.Value);
        else
            Method(a, b);
    });
