    public static void myStaticMethod(string strInputVal)
    {
        // Do what same part
    }
    
    // When you call this method it is 
    public static void myStaticMethod()
    {
        string strInputVal = "Default";   
        //Do something for default value
        System.Console.WriteLine("I am indetified as called with default value");
        myStaticMethod(strInputVal);
    }
