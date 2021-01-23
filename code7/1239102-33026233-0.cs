            Console.WriteLine("How much is rent: ");
            string strRent = Console.ReadLine();
            double dblRent = 0.0;
            while (!double.TryParse(strRent, out dblRent))
            {
                Console.WriteLine("Enter a number");
                strRent = Console.ReadLine();
            }
            Console.WriteLine("How much is the car payment: ");
            string strCarPayment = Console.ReadLine();
            double dblCarPayment = Convert.ToDouble(strCarPayment);
