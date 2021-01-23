        UInt32 attributePoints = 25;
        string inputStrength;
        string inputSpeed;
        UInt32 validStrength = 0;
        UInt32 validSpeed = 0;
        while (true)
        {
            Console.WriteLine("You have: " + attributePoints + " attribute points remaining to choose from");
            Console.Write("Please enter a value between 1-10 for strength: ");
            inputStrength = Console.ReadLine();
            if (!UInt32.TryParse(inputStrength, out validStrength))
                Console.WriteLine("Input was not a valid value for strength.");
            else if (validStrength < 0 || validStrength > 10)
                Console.WriteLine("Input was not a valid value for strength.");
            else
                break;
        }
        while (true)
        {
            Console.Write("Please enter a value between 1-10 for speed: ");
            inputSpeed = Console.ReadLine();
            if (!UInt32.TryParse(inputSpeed, out validSpeed))
                Console.WriteLine("Input was not a valid value for speed.");
            else if (validSpeed < 0 || validSpeed > 10)
                    Console.WriteLine("Input was not a valid value for speed.");
            else
                 break;
        }
        Console.WriteLine(String.Format("Strength Value = {0}", validStrength));
        Console.WriteLine(String.Format("Speed Value = {0}", validSpeed));
    
