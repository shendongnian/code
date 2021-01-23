			Console.WriteLine("Please enter hours.");
			var hoursWorked = Convert.ToDouble(Console.ReadLine());
			Console.WriteLine("Please enter pay rate");
			var payRate = Convert.ToDouble(Console.ReadLine());
			Console.WriteLine("Please enter tax.");
			var tax = Convert.ToDouble(Console.ReadLine());
			Console.WriteLine("\nGross Pay            " + (hoursWorked * payRate).ToString("c"));
			Console.WriteLine("Tax                    " + ((hoursWorked * payRate) * (tax / 100)).ToString("c"));
			Console.WriteLine("Net Pay                " + ((hoursWorked * payRate) - ((hoursWorked * payRate) * (tax / 100))).ToString("c"));
