        string inValue = "";
        double outcome = -1;
        Console.WriteLine("Enter amount: ");
	    while (outcome < 0){
          inValue = Console.ReadLine();
   	      if (double.TryParse(inValue, out outcome) == false)
          {
            Console.WriteLine("Initial value must be of the type double");
            Console.WriteLine("\nPlease enter the number again: ");
	        continue;
          }
          if (outcome>=0) {continue;}
          Console.WriteLine("Initial value must be of at least a value of zero");
          Console.WriteLine("\nPlease enter the number again: ");
        }
        return outcome;
