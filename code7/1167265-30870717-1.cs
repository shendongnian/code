        // iCount starts at 0
		Console.WriteLine(MyModule.CheckModulus());   // true because 0 % 6 == 0
		MyModule.Increment();                         // iCount == 1
		Console.WriteLine(MyModule.CheckModulus());   // false
		MyModule.Increment();                         // 2
		MyModule.Increment();                         // 3
		MyModule.Increment();                         // 4
		MyModule.Increment();                         // 5
		MyModule.Increment();                         // 6
		Console.WriteLine(MyModule.CheckModulus());   // true because 6 % 6 == 0
