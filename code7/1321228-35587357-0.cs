    static void Main(string[] args)
        {
            char[] guessed = new char[26];
            char[] testword = "******".ToCharArray();
            char[] word = "miller".ToCharArray();
            char[] copy = word;
            char guess;
            int score = 0, index = 0;
            Console.WriteLine(testword);
            for (int i = 0; i < 10; i++)
            {
                Console.Write("Please enter a letter to guess: ");
                guess = char.Parse(Console.ReadLine());
                bool right = false;
                for (int j = 0; j < copy.Length; j++)
                {
                    if (copy[j] == guess)
                    {
                        Console.WriteLine("Your guess is correct.");
                        testword[j] = guess;
                        guessed[index] = guess;
                        index++;
                        right = true;
                    }
                }
                if (right != true)
                {
                    Console.WriteLine("Your guess is incorrect.");
                    score++;
                }
                else
                {
                    right = false;
                }
                Console.WriteLine(testword);
            }
            Console.WriteLine("Your score is " + score);
            Console.ReadLine();
        }
