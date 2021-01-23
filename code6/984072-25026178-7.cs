    if (classINeedToDetermine is DerivedClass1)
    {
        var typed = (DerivedClass1)result;
        Console.WriteLine(typed.DerivedClass1Prop1);
        Console.WriteLine(typed.DerivedClass1Prop2);
    }
    else if (classINeedToDetermine is DerivedClass2)
    {
        var typed = (DerivedClass2)result;
        Console.WriteLine(typed.DerivedClass2Prop1);
        Console.WriteLine(typed.DerivedClass2Prop2);
    }
