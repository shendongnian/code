    namespace ConsoleApplication4
    {
        class Program
        {
            static void Main(string[] args)
            {
                const string a = " You pressed a";
                const string b = " You pressed b";
    
                string input = Console.ReadLine();
    
                switch (input)
                {
                    case "a": // correction 1
                        ShowData(a);
                        break;
    
                    case "b": // correction 2
                        ShowData(b);
                        break;
    
                    default:
                        Console.WriteLine(" You did not type a or b");
                        Console.WriteLine();
                        Console.ReadLine();
                        break;
                }
            }
    
            static void ShowData(string a)
            {
                Console.WriteLine(a); // correction 3
            }
    
        }
    }
