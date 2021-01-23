        Console.Write("Do you smoke a cigarettes? Y/N: ");
        string answer = Console.ReadLine();
        while (answer.Length != 1) {
            Console.WriteLine("Character is one letter silly.");
            Console.Write("Do you smoke a cigarettes? Y/N: ");
            answer = Console.ReadLine(); }
        char response = answer[0];
        if (response == 'Y' || response == 'y')
        {
            //YES RESPONSE
        }
        else
        {
            //NO RESPONSE
        }
        Console.ReadLine();
