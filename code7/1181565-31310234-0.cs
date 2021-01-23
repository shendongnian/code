    // Your current implementation
    public void MyMethod(int a, int b)
    {
        MyPrivateMethod(a, b);
    }
    private void MyPrivateMethod(int a, int b)
    {
        var c = a + b;
        // some more code
    }
    // Private method inlined
    public void MyMethod(int a, int b)
    {
        var c = a + b;
        // some more code
    }
