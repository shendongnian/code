            Random Rnd = new Random();
            string[] words = { "M_R_", "I_R_E_" };
            var randomNumber = Rnd.Next(0, words.Length);
            Console.WriteLine(words[randomNumber]);
            Console.WriteLine("Please enter your name");
            string name = Console.ReadLine();
            int points = 0;
            if ((words[randomNumber]).Equals("I_R_E_") && name == "Israel")
            {
                points += 5;
                Console.WriteLine("Marks: {0}", points);
                Console.WriteLine("You won!!!!");
            }
            else if ((words[randomNumber]).Equals("M_R_") && name == "Mark")
            {
                points += 5;
                Console.WriteLine("Marks: {0}", points);
                Console.WriteLine("You won!!!!");
            }
            else
            {
                Console.WriteLine("Incorrect");
            }
