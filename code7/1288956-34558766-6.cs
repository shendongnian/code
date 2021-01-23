    public static string Receive(int value) 
        => string.Format("Received: {0, 15:C}", value);
    public static string Receive6(int value) 
        => $"Received: {value,15:C}";
    Console.WriteLine(Receive(1));
    Console.WriteLine(Receive6(1));
    Console.WriteLine($"Current data: {DateTime.Now: MM/dd/yyyy}")
