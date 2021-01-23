    static void Main()
        {
            char[] array = new char[5];
            Console.WriteLine("Please Enter 5 Letters B/W a through j only: ");
            string letters = "abcdefghij";
            int counter = 0;
            while (counter < 5)
            {
                string input = Console.ReadLine().ToLower();
                char myChar = input[0];
                if (input.Length != 1 || array.Contains(myChar) || !letters.Contains(myChar))
                {
                    Console.WriteLine("You have entered an incorrect value");
                    continue;
                }
                array[counter++] = myChar;
            }
            Console.WriteLine("You have Entered the following Inputs: ");
            Console.WriteLine(string.Join(", ", array));
        }
