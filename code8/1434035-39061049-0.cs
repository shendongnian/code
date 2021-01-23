    using System;
					
    public class Program
    {
	    public static void Main()
	    {
		    try
		    {
		    	int totalAmount = 0;
		    	
		    	Console.WriteLine("Insert the number of adult tickets sold (1 for exit)");    
			    int adultTickets = Convert.ToInt32(Console.ReadLine());
			    if(adultTickets >= 5 && adultTickets <= 30)
			    {
				    totalAmount = adultTickets * 30;
			    }
			
			    Console.WriteLine("Insert the number of child tickets sold (1 for exit)");
			    int childTickets = Convert.ToInt32(Console.ReadLine());
			    if(childTickets >= 5 && childTickets <= 30)
			    {
				    totalAmount += childTickets * 20;
			    }
			    Console.WriteLine(totalAmount);
		    }
		    catch(FormatException)
		    {
		    	Console.WriteLine("Value input was not an integer.");
		    }
	   }
    }
