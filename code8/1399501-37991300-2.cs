    public static MyClass()
    {
        //configure static variables on first us only
        b = //read value from file or other resource not avalable at compile time
        a = b.Lenth; //can't be be done in class body as b would not have been initialised yet
    }
    private static int a;
    private static string b;
