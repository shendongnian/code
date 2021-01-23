    public static void addItem()
    {
        Console.WriteLine("\nAmount of items to add");
        item = Convert.ToInt32(Console.ReadLine());
		
        // initialize static vars to correct size, now that we have #items
		product = new string[item];
        code = new string[item];
        price = new string[item];
        unit = new string[item];
		
        Console.WriteLine("Insert the items.");
        for (int i = 0; i < item; i++)
        {
            Console.WriteLine("\nItem[" + i + "]: ");
            Console.Write("Product[" + i + "]: ");
            product[i] = Console.ReadLine();
            Console.Write("Code[" + i + "]: ");
            code[i] = Console.ReadLine();
            Console.Write("Price[" + i + "]: ");
            price[i] = Console.ReadLine();
            Console.Write("Unit[" + i + "]: ");
            unit[i] = Console.ReadLine();
        }
    }
