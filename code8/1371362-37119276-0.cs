    public class Program
    {
        public static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Enter an ID, q to quit");
                string line = Console.ReadLine();
                if (line == "q")
                    break;
                int myId = int.Parse(line); // note this will throw if you enter a non int (and not q)
                OutputInformation(myId);
            }
            Console.WriteLine("Done");
        }
        public static void OutputInformation(int Id)
        {
                NorthwindEntities nwe = new NorthwindEntities();
                var customerOrdersDetail = nwe.CustOrdersDetail(myId);
				
                foreach (var ordersDetail in customerOrdersDetail)
                {
                    Console.WriteLine(ordersDetail.ProductName);
                    Console.WriteLine(ordersDetail.UnitPrice);
                    Console.WriteLine(ordersDetail.Quantity);
                    Console.WriteLine(ordersDetail.ExtendedPrice);
                    Console.WriteLine(ordersDetail.Discount);
                    Console.ReadLine();
                }
        }
    }
