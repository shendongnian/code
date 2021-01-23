    Console.WriteLine(new decimal(0, 0, 0, false, 0)); //0
    Console.WriteLine(new decimal(1, 0, 0, false, 0)); //1
    Console.WriteLine(new decimal(0, 1, 0, false, 0)); //4294967296
    Console.WriteLine(new decimal(0, 0, 1, false, 0)); //18446744073709551616
    Console.WriteLine(new decimal(1, 0, 0, false, 1)); //0.1
    Console.WriteLine(new decimal(1, 0, 0, true, 1)); //-0.1
