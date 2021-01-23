    Console.WriteLine("FIND ITEM");
    Console.Write("Item code: ");
    int selectedCode = int.Parse(Console.ReadLine());
    
    //use LINQ to search for the item
    Item selectedItem = listOfItems.Where(i => i.Code == selectedCode).FirstOrDefault();
    
    //check if an item was found
    if (selectedItem != null)
    {
       Console.WriteLine("Item found!");
       //print the item
       Console.WriteLine("Code: {0}", selectedItem.Code);
       Console.WriteLine("Description: {0}", selectedItem.Description);
       Console.WriteLine("Price: {0}", selectedItem.Price.ToString("c"));
       Console.WriteLine("Quanitty: {0}", selectedItem.Quantity);
    }
