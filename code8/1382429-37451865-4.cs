    public static void addItem()
    {
        Console.Clear();
        Console.Write("\nNumber of items to add: ");
        count = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Insert the items:");
        for (int i = 0; i < count; i++) //note use of zero-based array
        {
            item.Add(new MyClass());
            Console.WriteLine("\nitem[" + i + "]: ");
            Console.Write("item[" + i + "].Item: ");
            item[i].Item = Console.ReadLine();
    
            Console.Write("item[" + i + "].Code: ");
            item[i].Code = Console.ReadLine();
    
            Console.Write("item[" + i + "].Price: ");
            item[i].Price = Console.ReadLine());
    
            Console.Write("item[" + i + "].Unit: ");
            item[i].Unit = Console.ReadLine();
        }
    }
