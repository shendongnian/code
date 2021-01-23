            bool flag0 = true;
            int result;
            Console.WriteLine("Welcome to our Multiplex");
            Console.WriteLine("We are presently Showing:");
            Console.WriteLine("1.Legend");
            Console.WriteLine("2.Macbeth");
            Console.WriteLine("3.Everest");
            Console.WriteLine("4.A Walk In the Woods");
            Console.WriteLine("5.Hotel Transylvania");
            do
            {
                Console.WriteLine("Enter the number of the film you wish to see?");
                string moviestring = Console.ReadLine();
                int.TryParse(moviestring, out result);
                if (result <= 5 && result >= 1)
                    flag0 = false; //exits the loop
                //do true logic....
                else
                {
                    Console.WriteLine("Incorrect value. Try again.");
                }
            } while (flag0);
