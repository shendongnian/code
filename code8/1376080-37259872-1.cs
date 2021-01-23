    Console.WriteLine(" Enter your scoreCA: ");
    double scoreCA = double.Parse(Console.ReadLine());
    Console.WriteLine(" Enter your scoreExam: ");
    double scoreExam = double.Parse(Console.ReadLine());
    double[] scoreTotal;
    for (i=0, i<10, i++)
    {
        scoreTotal[i] = scoreExam + scoreCA;
        if (scoreTotal < 0 || scoreTotal > 100)
        {
            Console.WriteLine("invalid");
        }
        else if (scoreTotal <= 100 && scoreTotal > 69)
        {
            Console.WriteLine("Your Grade is A");
        }
        else if (scoreTotal < 70 && scoreTotal > 59)
        {
            Console.WriteLine("Your grade is B");
        }
        else if (scoreTotal < 60 && scoreTotal > 59)
        {
            Console.WriteLine("Your grade is C");
        }
        else if (scoreTotal < 50 && scoreTotal > 44)
        {
            Console.WriteLine("Your grade is D");
        }
        else (scoreTotal < 45 && scoreTotal >= 0);
        {
            Console.WriteLine("Your grade is F");
            Console.ReadKey();
        }
    }
