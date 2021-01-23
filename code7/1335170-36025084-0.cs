    class Program
    {
        static void Main(string[] args)
        {
            char selection = read_or_write();
            Console.WriteLine("char in main function: "+selection);
            Console.WriteLine("press enter to close");
            Console.ReadLine(); //clean with enter keyboard
        }
        public static char read_or_write()
        {
            char selection;
            Console.WriteLine("Would you like to read (r) or write (w) to a file?");
            do
            {
                selection = (char)Console.Read();
                Console.ReadLine();//clean with enter keyboard
                if (selection == 'r')
                {
                    Console.WriteLine("You pressed r");
                    break;
                }
                else if (selection == 'w')
                {
                    Console.WriteLine("You pressed w");
                    break;
                }
                else
                {
                    Console.WriteLine("You pressed a wrong key!");
                }
            } while (selection != 'r' || selection != 'w');
            return selection;
        }
    }
