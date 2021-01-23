    Lazy<StreamWriter> sw = new Lazy<StreamWriter>(() => new StreamWriter(@"d:\abc.txt"));
    try
    {
        if (something)
        {
            sw.Value.WriteLine("Foo");
        }
    }
    finally
    {
        if (sw.IsValueCreated)
        {
            sw.Value.Dispose();
        }
    }
