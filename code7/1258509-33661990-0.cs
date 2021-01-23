    using Integer = System.Int32;
    var s = "a string";
    Console.WriteLine(nameof(s));
    Console.WriteLine(nameof(Integer));
    Console.WriteLine(nameof(System.Int32));
    void M<T>() { Console.WriteLine(nameof(T)); }
    M<int>();
    M<string>();
