            int choice;
            do
            {
                Console.WriteLine("WELCOME TO THE SHOPPING CART!\nFollowing options are available to you:\n1. Add an item to cart\n2. Remove an item from the cart\n3. View the cart\n4. Checkout and Pay\n5. Exit");
                Console.WriteLine("please inter your chice");
                choice = Int32.Parse(Console.ReadLine());
                if (choice == 1)
                {
                    Console.WriteLine("Available items are:\n1.shirt\n2.pant\n3.shoes\n4.fish\n5.oil");
                    Console.WriteLine("please inter the items name:");
                    string j = Console.ReadLine();
                }
            } while (choice != 5);
