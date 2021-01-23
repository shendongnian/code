        public static void addItem()
        {
            Console.WriteLine("\nAmount of items to add");
            item = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Insert the items.");
            for (int i = 0; i < item; i++)
            {
				var product = new Product();
                Console.WriteLine("\nItem[" + i + "]: ");
                Console.Write("Product[" + i + "]: ");
                product.Name = Console.ReadLine();
                Console.Write("Code[" + i + "]: ");
                product.Code = Console.ReadLine();
                Console.Write("Price[" + i + "]: ");
                product.Price = double.Parse(Console.ReadLine());  //read as double value.
                Console.Write("Unit[" + i + "]: ");
                product.Unit = int.Parse(Console.ReadLine()); // Read as int value
				
				products.Add(product); // products is global/class variable.
            }
        }
