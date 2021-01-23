    foreach (byte i in buffer)
    {
        Console.Write("{0:X2} ", i); // <- A byte is being passed.
    }
    Console.WriteLine("{0:X2}", string.Join(", ", buffer)); // <- A string is being passed.
