    static void Main(string[] args)
    {
        bool continueApplication = true;
        while(continueApplication) {
        //Förberedelser
        Random numberGenerator = new Random();
        int num01 = numberGenerator.Next(1,11);
        int num02 = numberGenerator.Next(1,11);
        //Frågan
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("Vad är ");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write(num01 + " ");
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("gånger ");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write(num02);
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine(" ?");
        //Svaret
        Console.ForegroundColor = ConsoleColor.Magenta;
        int numKey = Convert.ToInt32 (Console.ReadLine());
        if (numKey == num01 * num02)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n Grattis du svarade rätt!");
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("\n Du svarade tyvärr fel. \n Svaret är ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(num01 * num02);
        }
        Console.WriteLine("Do you want to continue(y/n)?");
        //Read what the user typed
        string result = Console.ReadLine();
        //Will allow N as well
        result = result.ToLower();
        //Check if the user typed n
        if(result == "n") {
            continueApplication = false;
        }
    }
