    int numbers = 10;
    double[] allNumbers = new double[numbers];
    for (int i = 0; i < numbers; i++)
    {
        Console.Write("What is the {0}. number? ", i + 1);
        double num;
        if (double.TryParse(Console.ReadLine().Trim(), out num))
        {
            allNumbers[i] = num;
        }
        else
        {
            i--; // ask the user until we have the numbers
            Console.Beep();
            Console.WriteLine("");
            Console.WriteLine("You have entered an invalid number!");
            Console.WriteLine("");
        }
    }
    double answer = allNumbers.Sum(); // LINQ so add using System.Linq;
