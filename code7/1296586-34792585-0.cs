    int a;
    int B { get; set; }
    void F()
    {
        a = 0;
        G(a); // a will be incremented
        B = 0;
        G(B); // Compiler error
    }
    void G(ref int p)
    {
        ++p;
    }
