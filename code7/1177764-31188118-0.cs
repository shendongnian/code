    Random randem = new Random();
    char[] characters = input.ToCharArray();
    for(int i = 1; i < length; i += 2)
    {
        int num = randem.Next(0, 9);
        char num1 = Convert.ToChar(num);
        characters[i] = num1;
    }
    output = new string(characters);
    Console.WriteLine(output);
