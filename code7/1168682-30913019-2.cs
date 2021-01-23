    Double? num1 = null;
    while (num1==null){
       Console.Write ("What is the first number? ");
       try {
           num1 = Convert.ToDouble (Console.ReadLine ());
       } catch (System.FormatException) {
           Console.Beep ();
           Console.WriteLine ("");
           Console.WriteLine ("You have entered an invalid number!");
           Console.WriteLine ("");
       }
    }
