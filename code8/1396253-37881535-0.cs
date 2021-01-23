    namespace yourapp.mainwindoe
    {
        class YourClass
        {
            internal static YourMethod()
            {
               yourapp.menuitem1.YourOtherMethod();
            }
    }
    
    namespace yourapp.menuitem1 
    {
        class YourClassOther
        {
            internal static YourOtherMethod()
            {
               // do something here...
            }
    }
