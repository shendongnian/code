    static void Main(string[] args)
        {
            int par = 3;
            int strokes = 4;
            int score;
            Console.Write("Enter Score ");
            if (!Int32.TryParse(Console.ReadLine(), out par))
            {
                Console.WriteLine("invalid input; conversion failed");
            }
            if (!Int32.TryParse(Console.ReadLine(), out strokes))
            {
                Console.WriteLine("invalid input; conversion failed");
            }
            if (!Int32.TryParse(Console.ReadLine(), out score))
            {
                Console.WriteLine("invalid input; conversion failed");
            }
            // Now you will get all values; so you can proceed
            if (score < par)
                Console.WriteLine("Score is below par.");
            else if (score > par)
                Console.WriteLine("Score is above par.");
            else if (score == par)
                Console.WriteLine("Score is equal to par.");
        }
