            ConsoleKeyInfo ch = new ConsoleKeyInfo();
            while (ch.KeyChar != 'e')
            {
                Console.WriteLine("type string to seed color");
                string s = Console.ReadLine(); // gets text from input, in this case the command line
                double d=0;
                foreach(char cha in s.ToCharArray())
                {
                    d=+ (int)cha; // get the value and adds it 
                }
                d= (255/(Math.Pow(0.2,-0.002 *d))); // Generates a seed like value from i where 255 is the maximum. basicly 255/0.2^(-0.002*d)
                int i = Convert.ToInt32(d); //then convets and get rid of the decimels
                Color c = Color.FromArgb(i, i, i);// add a bit more calculation for varieng colers.
                Console.WriteLine(c.Name);
                Console.WriteLine("To Exit press e");
                ch = Console.ReadKey()
           }
