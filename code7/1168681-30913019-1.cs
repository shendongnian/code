    Double? num1 = null;
    while (num1==null){
       try {
           num1 = Convert.ToDouble (Console.ReadLine ());
       } catch (System.FormatException) {
           Console.Beep ();
           Console.WriteLine ("");
           Console.WriteLine ("You have entered an invalid number!");
           Console.WriteLine ("");
           num1 = null;
       }
    }
