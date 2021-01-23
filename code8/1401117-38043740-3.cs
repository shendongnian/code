    Type[] typesToCheck = { typeof(ThatClass), typeof(ThatOtherClass) };
    ThatClass input1 = new ThatClass();
    ThatOtherClass input2 = new ThatOtherClass();
    if (IsOfAnyType(input1, typesToCheck))
        Console.WriteLine("Hello world from " + input1.GetType());
    if (IsOfAnyType(input2, typesToCheck))
        Console.WriteLine("Hello world from " + input2.GetType());
