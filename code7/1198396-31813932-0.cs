    class Test2
    {
    private int _x = -1; // The default value is -1
    private int x{
        get
        {
            return _x; // return whatever is in _x
        }
        set
        {
            _x = 5; // Change _x to 5 (or whatever is in value)
        }
    }
    public Test2(){
        Console.WriteLine("Test2: " + x); // should show -1
        Test2.x = 8;
        Console.WriteLine("Test2: " + x); // should show 8
    }
    }
