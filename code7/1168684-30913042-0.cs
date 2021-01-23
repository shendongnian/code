    private double? GetNumber()
    {
        double? result = null;
        try {
            result = Convert.ToDouble (Console.ReadLine ());
        } catch (System.FormatException) {
            Console.Beep ();
            Console.WriteLine ("");
            Console.WriteLine ("You have entered an invalid number!");
            Console.WriteLine ("");
        }
        return result;
    }
    ...
    // prompt for first number
    double? num1 = null;
    while (!num1.HasValue)
    {
       Console.Write ("What is the first number? ");
       num1 = GetNumber();
    }
    // prompt for second number
    double? num2 = null;
    while (!num2.HasValue)
    {
       Console.Write ("What is the second number? ");
       num2 = GetNumber();
    }
    // calculate result
    answer = num1.Value + num2.Value;
