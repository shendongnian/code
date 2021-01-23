    List<Item> listOfItems = new List<Item>();
    //we will create 10 items.
    for (int i = 0; i < 10; i++)
    {
        //instantiate the object
        Item item = new Item();
        Console.WriteLine("\n\tADD NEW ITEM\n\nPlease enter item details");
        Console.Write("Item code: ");
        item.Code = Console.ReadLine();
        Console.Write("Item description: ");
        item.Description = Console.ReadLine();
        Console.Write("Price: RM");
        item.Price = decimal.Parse(Console.ReadLine());
        Console.Write("Quantity: ");
        item.Quantity = int.Parse(Console.ReadLine());
       
        //we must add this item to our list
        listOfItems.Add(item);
    }
