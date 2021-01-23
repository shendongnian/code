    string input = "534-W1A-R1";
    string sub = input.Substring(0, 3);
    string sub2 = input.Substring(5, 1);
    string sub3 = input.Substring(6, 1);
    Console.WriteLine("Code={0} Phase={1} Zone={2}", sub, sub2, sub3);
