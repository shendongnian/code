        static void Main(string[] args)
        {
            Dictionary<string, stock> stocks = new Dictionary<string, stock>(StringComparer.CurrentCultureIgnoreCase);
            //Add the initial stocks here if desired.
            Console.WriteLine("Please enter a symbol");
            string symbol = Console.ReadLine();
            Console.WriteLine("Please enter yesterdays price for the symbol");
            double yestPrice = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Please enter Todays Price for the symbol");
            double currPrice = Convert.ToDouble(Console.ReadLine());
            if (stocks.ContainsKey(symbol))     //The dictionary contains the stock
            {
                stocks[symbol].YesterdaysPrice = yestPrice;
                stocks[symbol].CurrentPrice = currPrice;
            }
            else
            {
                //The stock wasn't found, we can either say invalid stock, or add one like this:
                stocks[symbol] = new stock()
                {
                    YesterdaysPrice = yestPrice,
                    CurrentPrice = currPrice;
                };
            }
        }
