    static void Main(string[] args)
    {
        Random R = new Random();
        double solution = 0;
        string sign = "";
        int score = 0;
        for (int i = 0; i < 10; i++)
        {
            int X = R.Next(1, 5);
            int Y = R.Next(1,10);
            int Z = R.Next(1,10);
            switch (X)
            {
                case 1:
                    solution = Y + Z;
                    sign = "+";
                    break;
                case 2:                       
                    solution = Y - Z;
                    sign = "-";
                    break;
                case 3:                        
                    solution = Y / Z;
                    sign = "/";
                    break;
                case 4:                        
                    solution = Y * Z;
                    sign = "X";
                    break;
            }
            Console.WriteLine("What is " + Y + " " + sign + " " + Z + "?");
            double answer = double.Parse(Console.ReadLine());
            if (answer == solution)
            {
                Console.WriteLine("Correct");
                score = score + 1;
            }
            else if (answer != solution)
            {
                Console.WriteLine("Incorrect. The correct answer is " + solution);
            }
        }
    }
