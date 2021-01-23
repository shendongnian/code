    cMyImplementationClass myImpClass = new cMyImplementationClass();
    IMyInterface myInterface = myImpClass as IMyInterface;
    
    myImpClass.CacheErrors = true;
    
    // Retrieve the error strings into the Array variable.
    Array test = myInterface.GetErrors();
    
    // You can access elements using the GetValue() method, which honours the array's original bounds.
    MessageBox.Show(test.GetValue(1) as string);
    
    // Alternatively, if you want to treat this like a standard 1D C# array, you will first have to copy this into a string[].
    string[] testCopy = new string[test.GetLength(0)];
    test.CopyTo(testCopy, 0);
    MessageBox.Show(testCopy[0]);
