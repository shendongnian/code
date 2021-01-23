        string name = "";
        while (name.equals(""))
        {
            name = (Console.ReadLine());
            Console.WriteLine("Is " + name + " ok?");
        
            String answer = "";
            while(answer.equals(""))
            {
                Console.WriteLine("\n(Y)es\n(N)o");
                char ansys = Console.ReadKey();
                if (ansys == ConsoleKey.Y || ansys == ConsoleKey.N)
                {
                    answer = ansys.ToString();
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Enter letters only!!");
                }
            }
            if(!answer.equals("Y"))
                name = "";
        }
