            List<decimal> prices = new List<decimal>();
            int numPrices;
            decimal totalPrice;
            decimal averagePrice;
            string inputString;
            int lessThanFive = 0;
            int higherThanAverage = 0;
            Console.Write("Enter the number of prices that you will be entering: ");
            numPrices = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < numPrices; i++)
            {
                Console.Write("Enter the price for item #{0}: $", i+1);
                inputString = Console.ReadLine();
                prices.Add(Convert.ToDecimal(inputString));
            }
            totalPrice = prices.Sum();
            averagePrice = prices.Average();
            foreach (decimal item in prices)
            {
                if (5 > item)
                {
                    lessThanFive++;
                }
                if (averagePrice > item)
                {
                    higherThanAverage++;
                }
            }
            Console.WriteLine();
            Console.WriteLine("The sum of the values are: {0:C}", totalPrice);
            Console.WriteLine("The number of prices less than $5.00 are: {0}", lessThanFive);
            Console.WriteLine("The average of the prices entered is: {0:C}", averagePrice);
            Console.WriteLine("The number of prices that are higher than average are: {0}", higherThanAverage);
            Console.ReadLine();
