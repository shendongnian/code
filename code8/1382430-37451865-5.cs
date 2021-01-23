    public static void searchItem()
    {       
        Console.WriteLine("Type the code to search an article");
        string code = Console.ReadLine();
        for (int i = 0; i < item.Count; i++)
        {
           if (item[i].Code == code)
           {
              Console.WriteLine("The item's Item is: " + item[i].Item);
              Console.WriteLine("The item's Code is: " + item[i].Code);
              Console.WriteLine("The item's Price is: " + item[i].Price);
              Console.WriteLine("The item's Unit is: " + item[i].Unit);
           }
         }
    }
