    public static void myStaticMethod()
    {
        myInternalStaticMethod ("Default", true);
    }
    public static void myStaticMethod(string inputValue)
    {
        myInternalStaticMethod (inputValue, false);
    }
    private static void myInternalStaticMethod(string inputValue, bool isDefault)
    {
        if (isDefault) {
                //Do something
        } else {
                //Do some other task
        }
    }
