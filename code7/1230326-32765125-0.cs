            static readonly IDictionary<string, Stock> Stocks = new Dictionary<string, Stock>();
            static void Main(string[] args)
            {
    
                Console.WriteLine("Please enter a symbol for Apple or Facebook");
                var symbol = Console.ReadLine(); //this should get the class to work on
    
                Console.WriteLine("Please enter yesterdays price for the symbol");
                var yestPrice = Convert.ToDouble(Console.ReadLine());
    
                Console.WriteLine("Please enter Todays Price for the symbol");
                var currPrice = Convert.ToDouble(Console.ReadLine());
    
    
                Stock stock;
                if (Stocks.ContainsKey(symbol))
                    stock = Stocks[symbol];
                else
                {
                    stock=new Stock();
                    Stocks[symbol] = stock;
                }
    
                
                stock.YesterdaysPrice = yestPrice;
                stock.CurrentPrice = currPrice;
    
            }
