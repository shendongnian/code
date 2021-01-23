    void Main()
    {
        var t = new Test(XYZ);
        t();
        t(15);
    }
    
    public delegate void Test(int a = 10);
    
    public void XYZ(int a)
    {
        a.Dump();
    }
