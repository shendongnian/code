    do	
    {
    	Console.WriteLine("Please enter a year: ");
    	if(!int.TryParse(Console.ReadLine(), out Year))
        {
              Console.WriteLine("invalid input");
              continue;
        }
    	
    	if ((Year % 4 == 0) && (Year % 100 != 0 || Year % 400 != 0)) // <--- entered 2016
    	{
    		Console.WriteLine("The Year you have entered is a Leap Year {0}.", Year);
    	}
    	if ((Year % 4 == 0) && (Year % 100 == 0)) // <--- year 2000
    	{
    		Console.WriteLine("the 2000 works", Year);
    	}
    	if ((Year % 5 == 0) && (Year % 100 != 0)) // <--- year 2015
    	{
    		Console.WriteLine("2015 works", Year);
    	}
    	
    	
    }	while(Year != -1);
    
    //Console.ReadLine(); not required.
