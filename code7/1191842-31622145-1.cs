    {
        private static void Main(string[] args)
        {
            do
            {
                Console.WriteLine("Main Menu");
                Console.WriteLine("Press 1 for cars");
                Console.WriteLine("Press 2 for planes");
                Console.WriteLine("Press 3 for boats");
                Console.WriteLine("Enter 'q' to exit");
                ConsoleKeyInfo _key = Console.ReadKey();
                switch ((char) _key.Key)
                {
                    case '1':
                    {
                        Console.Clear();
                        CarMenu();
                        break;
                    }
                    case '2':
                    {
                        Console.Clear();
                        //PlaneMenu();
                        break;
                    }
                    case '3':
                    {
                        Console.Clear();
                        //BoatMenu();
                        break;
                    }
                    case 'Q':
                    {
                        Environment.Exit(0);
                        break;
                    }
                    default:
                    {
                        Console.WriteLine("No options to that key...");
                        Console.WriteLine("-------------------------\n\n");
                        break;
                    }
                }
            } while (true);
        }
        public static void CarMenu()
        {
            do
            {
                Console.Clear();
                Console.WriteLine("Car menu");
                Console.WriteLine("Press 1 to list all cars");
                Console.WriteLine("Press 2 to list single car");
                Console.WriteLine("Press 3 to register a new car");
                Console.WriteLine("Press 0 for main menu");
                Console.WriteLine("Enter 'q' to exit");
                ConsoleKeyInfo _key = Console.ReadKey();
                Console.WriteLine((char) _key.Key);
                //Console.ReadKey();
                switch ((char) _key.Key)
                {
                    case '1':
                    {
                        Console.Clear();
                        Console.WriteLine("1");
                        //_handler.listAllDevices();
                        break;
                    }
                    case '2':
                    {
                        Console.Clear();
                        Console.WriteLine("1");
                        break;
                    }
                    case '3':
                    {
                        Console.Clear();
                        Console.WriteLine("1");
                        break;
                    }
                    case '0':
                    {
                        Console.Clear();
                        return;
                    }
                    case 'Q':
                    {
                        Environment.Exit(0);
                        return;
                    }
                    default:
                    {
                        Console.WriteLine("No options to that key...");
                        Console.WriteLine("-------------------------\n\n");
                        break;
                    }
                }
            } while (true);
        }
    }
