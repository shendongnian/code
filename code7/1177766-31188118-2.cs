    Random randem = new Random();
    char[] characters = input.ToCharArray();
    for(int i = 1; i < length; i += 2)
    {
        int num = randem.Next(1, 10); // max value is exclusive
        char num1 = num.ToString()[0];
        characters[i] = num1;
    }
    output = new string(characters);
    Console.WriteLine(output);
