      public class Menu
      {
        public static int item { get; set; }
        public static List<string> product = new List<string>();
        public static List<string> code = new List<string>();
        public static List<string> price = new List<string>();
        public static List<string> unit = new List<string>();
        public void showMenu()
        {
            //Menu 
            while (true)
            {
                Console.WriteLine("\n1.- Add new item");
                Console.WriteLine("2.- Show items");
                Console.WriteLine("3.- Exit \n");
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
            item = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Insert the items.");
            for (int i = 1; i <= item; i++)
            {
                Console.WriteLine("\nItem[" + i + "]: ");
                Console.Write("Product[" + i + "]: ");
                product.Add(Console.ReadLine());
                Console.Write("Code[" + i + "]: ");
                code.Add(Console.ReadLine());
                Console.Write("Price[" + i + "]: ");
                price.Add(Console.ReadLine());
                Console.Write("Unit[" + i + "]: ");
                unit.Add(Console.ReadLine());
            }
        }
        public static void showItems()
        {
            Console.WriteLine("******* SHOW ITEMS *******");
            Console.WriteLine("Product ------------- Code ------------- Price ------------- Unit");
            for (int i = 0; i < item; i++)
            {
                Console.WriteLine(product[i] + "                 " + code[i] + "                    " + price[i] + "                     " + unit[i]);
            }
        }
    }
