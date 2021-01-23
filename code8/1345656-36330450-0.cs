    private void MyMethod(ref IDisposable foo)
    {
        // This is a valid statement, since SqlConnection implements IDisposable
        foo = new SqlConnection();
    }
