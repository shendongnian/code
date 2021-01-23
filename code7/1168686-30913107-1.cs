    private Double InputNum1
    {
        Console.Write ("What is the first number? ");
        try 
        {
            num1 = Convert.ToDouble (Console.ReadLine ());
            return num1;
        } 
        catch (System.FormatException) 
        {
            Console.Beep ();
            Console.WriteLine ("");
            Console.WriteLine ("You have entered an invalid number!");
            Console.WriteLine ("");
            InputNum1();
        }
    }
