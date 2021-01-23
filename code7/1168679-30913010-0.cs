    double num1;
    while (true) {
        Console.Write ("What is the first number? ");
        try {
            num1 = Convert.ToDouble (Console.ReadLine ());
            break;
        } catch (System.FormatException) {
            Console.Beep ();
            Console.WriteLine ("");
            Console.WriteLine ("You have entered an invalid number!");
            Console.WriteLine ("");
        }
    }
