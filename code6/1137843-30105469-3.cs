    static void firingDriver_ExceptionThrown(object sender, WebDriverExceptionEventArgs e)
    {
        Console.WriteLine(e.ThrownException.Message);
    }
        
    static void firingDriver_ElementClicked(object sender, WebElementEventArgs e)
    {
        Console.WriteLine(e.Element);
    }
    static void firingDriver_FindElementCompleted(object sender, FindElementEventArgs e)
    {
        Console.WriteLine(e.FindMethod);
    }
