            string pw = "123";
            Console.WriteLine("Enter the first digit of the password");
            char toTest = (char) Console.Read();
            Console.Read();
            Console.Read();
            if (toTest == pw[0])
            {
                Console.WriteLine("Enter the second digit of the password");
                toTest = (char)Console.Read();
                Console.Read();
                Console.Read();
                if (toTest == pw[1])
                {
                    Console.WriteLine("Enter the third digit of the password");
                    toTest = (char)Console.Read();
                    Console.Read();
                    Console.Read();
                }
            }
        }`
