    void DoStuff()
    {
        try
        {
           ...
        }
        catch(MyCustomException inner)
        {
           if (inner.ExceptionKind == MyCustomExceptionKind.MyCustomFatalException)
              throw;
           // handle inner, show message box
        }
    }
    void DoStuffTwice()
    {
       DoStuff();
       DoStuff();
    }    
    void Main()
    {
       try
       {
           DoStuffTwice();
       }
       catch(MyCustomException inner)
       {
           if (inner.ExceptionKind == MyCustomExceptionKind.MyCustomFatalException)
              return;
           // now what??
       }
    }
