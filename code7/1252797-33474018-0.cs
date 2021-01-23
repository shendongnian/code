    Console.OutputEncoding = Encoding.Default;
    Console.WriteLine("Default: {0} for {1}", s, Console.OutputEncoding.HeaderName);
    s = Encoding.ASCII.GetString(byteArray);
    Console.OutputEncoding = Encoding.ASCII;
    Console.WriteLine("ASCII: {0} for {1}", s, Console.OutputEncoding.HeaderName);
    s = Encoding.UTF8.GetString(byteArray);
    Console.OutputEncoding = Encoding.UTF8;
    Console.WriteLine("UTF8: {0} for {1}", s, Console.OutputEncoding.HeaderName);
