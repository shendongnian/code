    static void Main(string[] args)
    {
        const string validValues = "abcdefghij";
        var enteredCharacters = new char[5];
        for (int i = 0; i < enteredCharacters.Length; i++)
        {
            Console.WriteLine("Please enter a unique character between a and j");
            var input = Console.ReadLine();
            if (input.Length == 0)
            {
                Console.WriteLine("You did not enter a value.");
                return;
            }
            if (input.Length > 1)
            {
                Console.WriteLine("You have entered more than 1 character");
                return;
            }
            var character = input[0];
            if (!validValues.Contains(character))
            {
                Console.WriteLine("You have entered an invalid character");
                return;
            }
            if (enteredValues.Contains(character))
            {
                Console.WriteLine("You have already entered this character");
                return;
            }
            enteredCharacters[i] = character;
        }
        // process numbers.
    }
