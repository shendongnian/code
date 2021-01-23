    {
        var A = new A();
        A.Number = 100;   // ok
        var B = new B(A);
        B.Number = 200;   // error
        Console.WriteLine(B.Number);  // prints 100
    }
