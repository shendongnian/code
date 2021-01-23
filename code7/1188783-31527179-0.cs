    void Main()
    {
      int x;
      List<int> numbers = new List<int>();
      
      while (true)
      {
         Console.WriteLine ("Enter a whole number between 1 and 25 or 0 to end:");
    	 string input = Console.ReadLine();
    	 
    	 bool isInteger = int.TryParse(input, out x);
    	 
    	 if (!isInteger || x < 0 || x > 25)
    	 {
    	 	Console.WriteLine (@"Didn't I tell you ""Enter a whole number between 1 and 25 or 0 to end? Try again""");
    		continue;
    	 }
    	 
    	 if (x == 0)
    	 {
    	   if (numbers.Count () == 0)
    	   {
    	   	Console.WriteLine ("Pity you quit the game too early.");
    	   }
    	   else
    	   {
    	    Console.WriteLine (@"You have entered {0} numbers. The  numbers you entered were:[{1}]
    Their sum is:{2} 
    and their average is:{3}", 
               numbers.Count, 
    		   string.Join(",", numbers.Select (n => n.ToString())), 
    		   numbers.Sum(), 
    		   numbers.Average ());
           }
    	   break;
    	 }
    	 else
    	 {
    	   numbers.Add(x);
    	 }
       }
    }
