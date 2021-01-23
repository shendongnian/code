            double price;
            int region;
            string p;
            Console.Write("Enter the total price of items : ");
            price = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Select the your region.");
            Console.WriteLine("1 : Pakistan");
            Console.WriteLine("2 : UK");
            Console.WriteLine("3 : Cortia");
            p = Console.ReadLine();
            if (!int.TryParse(p, out region))
            {
                //error handle.
            }
            else
            {
                    //at this point, the region value already has the value of p;
            }
