    string texti = string.Empty;
    Console.WriteLine("");
    Console.WriteLine("Put in your sentence ..");
    texti = Console.ReadLine();
    
    Console.WriteLine("You entered the following ..");
    Console.WriteLine(texti);
    foreach (char str in texti)
    {
        switch (str)
        {
            case 'A':
            case 'a':
            case 'S':
            case 's':
            case 'N':
            case 'n':
                {
                    break;
                }
            default:
                {
                    texti = texti.Replace(str, '*');
                    break;
                }
        }
    }
    Console.WriteLine("Your new text");
    Console.WriteLine(texti);
