     {
            int par = 3;
            int strokes = 4;
            Console.WriteLine("Enter Score ");
            strokes = Convert.ToInt32(Console.ReadLine());
            if (strokes < par)
                Console.WriteLine("Score is below par.");
                else if (strokes > par)
                    Console.WriteLine("Score is above par.");
                        else if (strokes == par)
                          Console.WriteLine("Score is equal to par.");
        }
