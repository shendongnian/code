    private static void Main(string[] args)
    {
        FetchOrderDetail();
    }
    private static void FetchOrderDetail()
    {
        string input = string.Empty;
        while (input != "exit")
        {
            Console.WriteLine("Enter order detail ID: ");
            input = Console.ReadLine();
            int orderId = 0;
            if (Int32.TryParse(input, out orderId))
            {
                var customerOrdersDetail = nwe.CustOrdersDetail(orderId);
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
    }
    
