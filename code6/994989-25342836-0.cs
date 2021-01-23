    CDerivedClass deriveObject = new CDerivedClass();
    CBaseClass basePointer = new CDerivedClass();
    CDerivedClass notUsed;
    // deriveObject.iCount == 50
    // basePointer.iCount == 50
    
    Console.WriteLine("1:" + deriveObject.iCount); // 1:50
    deriveObject.Add();
    // CDerivedClass.Add is called on deriveObject
    // deriveObject.iCount == 70
    
    Console.WriteLine("2:" + deriveObject.iCount); // 2:70
    basePointer.Add(30);
    // CDerivedClass.Add is called on basePointer
    // basePointer.iCount == 80
    
    Console.WriteLine("3:" + basePointer.iCount); // 3:80
    basePointer.Subtract();
    // CBaseClass.Subtract is called on basePointer, since `CDerivedClass` does not
    // override the Subtract method.
    // basePointer.iCount == 60
    
    Console.WriteLine("4:" + basePointer.iCount); // 4:60
    basePointer.Subtract(20);
    // CDerivedClass.Subtract is called on basePointer. *Note* that this subtracts 10.
    // basePointer.iCount == 50
    
    Console.WriteLine("5:" + basePointer.iCount); // 5:50
    Console.WriteLine("6:{0}",basePointer);
    
    Console.ReadLine();
