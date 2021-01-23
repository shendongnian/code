      	double L = DateTime.Now.ToOADate() + 2415018.5 + 68569;
	   	   	
			double HMS = L-(int)L-0.5;	
		   	
			int Hours = (int)(24*HMS);
		 	HMS=HMS - (double)(Hours/24.0);
			int Mins = (int)(24*60*HMS);
			HMS=HMS - (double)(Mins/(24.0*60));
		
			int Secs = (int)(24*60*60*HMS);
		
            long N = (long)((4 * L) / 146097);
            L = L - ((long)((146097 * N + 3) / 4));
            long I = (long)((4000 * (L + 1) / 1461001));
            L = L - (long)((1461 * I) / 4) + 31;
            long J = (long)((80 * L) / 2447);
            int Day = (int)(L - (long)((2447 * J) / 80));
            L = (long)(J / 11);
            int Month = (int)(J + 2 - 12 * L);
            int Year = (int)(100 * (N - 49) + I + L);
		
		
		
            DateTime test = new DateTime(Year, Month, Day);
			Console.WriteLine("Hours-"+Hours);
		 	Console.WriteLine("Mins-" + Mins);
			Console.WriteLine("Secs-"+ Secs);
			
		    Console.WriteLine(test);
		Console.WriteLine(DateTime.Now.ToString());
   
