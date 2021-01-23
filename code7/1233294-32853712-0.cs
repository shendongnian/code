    // Receive the welcome message.
    int recv = ns.Read(data, 0, data.Length);
    string message = Encoding.ASCII.GetString(data, 0, recv);
    Console.WriteLine(message);
    // Receive the file size.
    int recv2 = ns.Read(data, 0, data.Length);
    string message2 = Encoding.ASCII.GetString(data, 0, recv2);
    Console.WriteLine(message2);
    // Receive the extensions.
    int recv1 = ns.Read(data, 0, data.Length);
    string message1 = Encoding.ASCII.GetString(data, 0, recv1);
    Console.WriteLine(message1);
