    MyIDisposableObject obj;
    try
    {
        obj = new MyIDisposableObject();
    }
    finally
    {
        if (obj != null)
        {
            ((IDisposable)obj).Dispose();
        }
    }
