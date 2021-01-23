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
                case "a":   //Case changed to "a" instead of a
                    ShowData(a);        //Here, we could use Console.writeLine(a) directly if we wanted.
                    Console.WriteLine();
                    Console.ReadLine();
                    break;
                case "b":   //Case changed to "b" instead of b
                    ShowData(b);    //Here, we could use Console.writeLine(b) directly if we wanted.
                    Console.WriteLine();
                    Console.ReadLine();
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
            Console.WriteLine(a);   //Changed from ShowData to a
        }
    }
    }
