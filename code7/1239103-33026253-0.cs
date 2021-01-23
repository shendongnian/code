            double dblRent = 0.0;
            Boolean valid = false;
            while (!valid)
            {
                if (double.TryParse(strRent, out dblRent))
                {
                    Console.WriteLine("How much is the car payment: ");
                    string strCarPayment = Console.ReadLine();
                    double dblCarPayment = Convert.ToDouble(strCarPayment);
                    valid = true;
                }
                else
                {
                    Console.WriteLine("Enter a number");
                }
            }​
