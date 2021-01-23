    Array2<int> array2 = new Array2<int>(10, 10);
    array2[0, 0] = 0;
    Console.WriteLine(array2.IsEmpty);
    array2[0, 0] = 1;
    Console.WriteLine(array2.IsEmpty);
    array2[0, 0] = 0;
    Console.WriteLine(array2.IsEmpty);
