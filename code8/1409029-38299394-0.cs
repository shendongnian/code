	    int n, c;
	    c = 0;
            Console.WriteLine("Enter A Number :");
            n = int.Parse(Console.ReadLine());
            for (int i = 2; i < n; i++)
	    { 
		if (n%i==0)
		{
			c++;
			if(c==1)
			{
		 	Console.WriteLine("This Number is Divisible by "+i);
			}
			else
			{
			Console.Write(" and "+i);
			}				
		}
		else
		{
	 	Console.WriteLine("This Number is Prime Number);
		}
	      }
