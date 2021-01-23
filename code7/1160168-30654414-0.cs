            while (!Regex.IsMatch(letter, "[a-zA-Z]"))
            {
                Console.WriteLine("Enter a letter please!");
                letter = Console.ReadLine();
            }
