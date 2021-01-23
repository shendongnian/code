        double a = 110.0;
        double b = a / 100.0;
        double c = Math.Round(b, 2); // c = 1.1
        if ((c % 0.05) == 0) // 1.1 % 0.05 = 0.000000000000000027755575615628914 which is not equal to 0.. thus it is false..
            Console.WriteLine("Good news!");
        else
            Console.WriteLine("Bad news!"); // Ooooh it's false, Bad news!
