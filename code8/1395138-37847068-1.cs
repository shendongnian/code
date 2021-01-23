    MyAClass aProp = MainForm.Instance.MyProperty.AProperty;
    aProp.TheProperty.AnInt = 4;
    MyClass newClassInst = new MyClass{ AnInt = 5 };
    MainForm.Instance.MyProperty.AProperty.TheProperty = newClassInst;
    // Now, since AProperty didn't change, you can reference the new object
    Console.WriteLine(aProp.TheProperty.AnInt); // Prints 5
