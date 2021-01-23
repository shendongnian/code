    MyClass _a;
    public MyClass A
    {
        get { return _a; }
        set
        {
            // find if programmer set A=new MyClass();
            if (value != _a)
            {
                // different value
            }
        }
    }
