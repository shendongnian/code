    namespace ConsoleApplication4
    {
    class Program
    {
        static void Main(string[] args)
        {
            demo obj = new demo();
            string uname, pass;
            boolean successful = false;
            int32 tries = 5;
            Console.ForegroundColor = ConsoleColor.Green;
        label1:
            Do 
            {
            Console.Clear();
            Console.WriteLine("Enter username");
            uname = Console.ReadLine();
            Console.WriteLine("Enter Password");
            pass = Console.ReadLine();
            obj.setName(uname);
            obj.setPass(pass);
            if (obj.getName() == "niit")
            {
                if (obj.getPass() == "1234")
                {
                    Console.WriteLine("welcome");
                    successful = true;
                }
            }
            if (!successful)
            {
                tries--;
                Console.Clear();
                Console.WriteLine("Invalid");
                if (tries > 1)
                { 
                   Console.WriteLine("Have " + tries + " attempts left");
                }
                ElseIf (tries == 1)
                {
                   Console.WriteLine("Have only one more attempt left");
                }
                Else
                {
                   Console.WriteLine("Maximum number of tries exceed");
                   Console.WriteLine("Goodbye");
                }
            }
            } While(!successful && Tries > 0);
        }
    }
