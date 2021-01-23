    using System;
    using System.Collections.Generic;
    
    namespace Market
    {
        public class Menu
        {
            public struct Item
            {
                public string product;
                public string code;
                public string price;
                public string unit;
            }
            public static List<Item> items = new List<Item>();
    
            public static void showMenu()
            {
                //Menu 
                while (true)
                {
                    Console.WriteLine("\n1.- Add new item");
                    Console.WriteLine("2.- Show items");
                    Console.WriteLine("3.- Exit");
    
                    string option = Console.ReadLine();
    
                    switch (option)
                    {
                        case "1":
                            addItem();
                            break;
                        case "2":
                            showItems();
                            break;
                        case "3":
                            System.Environment.Exit(-1);
                            Console.ReadKey();
                            break;
                        default:
                            Console.WriteLine("Select one valid option..");
                            break;
                    }
                }
    
            }
    
            public static void addItem()
            {
                Console.WriteLine("\nAmount of items to add");
                int numbItemsToAdd = Convert.ToInt32(Console.ReadLine());  // needs validation
                Console.WriteLine("Insert the items.");
                for (int i = 0; i < numbItemsToAdd; i++)
                {
                    Item item = new Item();
                    Console.WriteLine("\nItem[" + (i + 1) +"]: ");
                    Console.Write("Product[" + (i + 1) +"]: ");
                    item.product = Console.ReadLine();
    
                    Console.Write("Code[" + (i + 1) + "]: ");
                    item.code = Console.ReadLine();
    
                    Console.Write("Price[" + (i + 1) + "]: ");
                    item.price = Console.ReadLine();
    
                    Console.Write("Unit[" + (i + 1) + "]: ");
                    item.unit = Console.ReadLine();
    
                    items.Add(item);
                }
    
            }
    
            public static void showItems()
            {
                Console.WriteLine("******* SHOW ITEMS *******");
                Console.WriteLine("Product ------------- Code ------------- Price ------------- Unit");
    
                foreach(Item i in items)
                {
                    Console.WriteLine(i.product + "                " + i.code + "                   " + i.price + "                    " + i.unit);
                }
            }
    
    
    
            public static void Main()
            {
                showMenu();
            }
        }
    
    
    }
