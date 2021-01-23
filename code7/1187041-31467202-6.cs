    dynamic SomeMethod(int variable)
    {
       switch(variable)
       {
           case 1: return "text";
           case 2: return 5;
           // Or manually return something out of switch scope
           // because method have to return something
           default: return null;
       }
    }
    
    void Test()
    {
        // Now you have a value assigned to an variable
        // that comes from SomeMethod
        // which is generated (selected) by switch
        var result1 = SomeMethod(1); // string
        var result2 = SomeMethod(2); // int
        var result3 = SomeMethod(123); // null
    }
