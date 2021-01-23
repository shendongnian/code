    namespace ConsoleApplication1
    {
        class Program
        {
            static void menu()
            {
                Console.WriteLine("Select a category to view");
                Console.WriteLine("");
                Console.WriteLine("1.Groceries");
                Console.WriteLine("2.Electronics & Appliances");
                Console.WriteLine("3.Exit");
                Console.ReadKey();
                int User = int.Parse(Console.ReadLine());
                switch (User)
                {
                    case 1:
                        Console.WriteLine("...........Groceries...............");
                        break;
    
                    case 2:
                        Console.WriteLine("..............Electronics &   Appliances............");
                        break;
                    case 3:
                        Console.WriteLine("...........Exit...............");
                        break;
                }
            }
            static void Main(string[] args)
            {
                menu();
            }
        }
    }
