	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;
	
	namespace console_water
	{
		class water_amount
		{
			static void Main(string[] args)
			{
				/*variable decleration*/
				int multiply, divide;
				int userInput;
				multiply = 192;
				divide = 16;
	
				/*getting user input*/
				Console.WriteLine("Length of shower in minutes:");
	
				userInput = int.Parse(Console.ReadLine());
	
				int numBottlesMinute =  multiply / divide;
	
				Console.WriteLine("The amount of water used is:" + userInput * numBottlesMinute);
			}
		}
	}
