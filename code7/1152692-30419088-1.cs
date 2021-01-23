        using System;
		using System.Collections.Generic;
		namespace AverageNumbers
		{
			class MainClass
			{
				public static void Main (string[] args)
				{
                    // Here is the list of numbers
					List<int> numbers = new List<int>();
                    
                    // Here are two variables to keep track
                    // of the input number (n), and the sum total (sum)
					int n, sum = 0;
                    // This while loop waits for user input and converts
                    // that input to an integer
					while (int.TryParse(Console.ReadLine(), out n))
					{
                        // Here we add the entered number to the sum
						sum += n;
                        // And to the list to track how many we've added       
						numbers.Add(n);
					}
                    // Finally we make sure that we have more than 0 numbers that we're summing and write out their average
					Console.WriteLine("Average: " + (numbers.Count > 0? sum / numbers.Count : 0));
				}
			}
		}
