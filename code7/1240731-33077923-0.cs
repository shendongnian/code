            double answer;
            if (!double.TryParse(Console.ReadLine(), out answer))
            {
                Console.WriteLine("Error");
                continue;
            }
            
            if (answer == solution)
            {
                Console.WriteLine("Correct");
                score = score + 1;
            }
            else if (answer != solution)
            {
                Console.WriteLine("Incorrect. The correct answer is " + solution);
            }
