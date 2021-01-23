    string price;
            string amount;
            Console.Write("What is the price?");
            price = Console.ReadLine();
            double pricenumber;
            while (!double.TryParse(price, out pricenumber)) 
            {
                Console.WriteLine("You've not entered a price.\r\nPlease enter a price");
                price = Console.ReadLine();
            }
            Console.Write("How many were you planning on purchasing?");
            double amountnumber;
            amount = Console.ReadLine();
            while (!double.TryParse(amount, out amountnumber)) 
            {
                Console.WriteLine("You cannot leave this blank.\r\nPlease enter how many are needed:");
                amount = Console.ReadLine();
            }
