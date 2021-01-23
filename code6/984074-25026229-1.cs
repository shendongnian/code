    if (classINeedToDetermine is DerivedClass1)
    {
        var derived1 = (DerivedClass1)result;
        Console.WriteLine(derived1.DerivedClass1Prop1);
        // etc      
    }
    else if (classINeedToDetermine is DerivedClass2)
    {
        var derived2 = (DerivedClass2)result;
        Console.WriteLine(derived2.DerivedClass2Prop1);
        // etc   
    }
