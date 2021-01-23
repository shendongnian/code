    enum MyEnum
    {
       Value1 = 1,
       Value2 = 2
    };
    
    void Main()
    {
    	// Literal
    	Console.WriteLine(Convert.ToString(MyEnum.Value1)); // Value1
    	Console.WriteLine(MyEnum.Value1.ToString()); // Value1
    	// Variable
    	MyEnum myEnum = MyEnum.Value2;
    	Console.WriteLine(Convert.ToString(myEnum)); // Value2
    	Console.WriteLine(myEnum.ToString());  // Value2
    
    	// Invalid
    	MyEnum badEnum = (MyEnum)123;
    	Console.WriteLine(Convert.ToString(badEnum)); // 123
    	Console.WriteLine(badEnum.ToString()); // 123
    }
