        if (args.Length > 0)
        {
            int x = 10, y = 5;
            if (args[0] == "1")
            {
                Console.WriteLine("You are using the AddFunction");
                Console.WriteLine(string.Format("Result = {0}", AddTwo(x,y) ));
            }
            else if (args[0] == "2")
            {
                Console.WriteLine("You are using the subtractFunction");
                Console.WriteLine(string.Format("Result = {0}", subtractTwo(x,y) ));
            }
        }
