        private void DoIt()
        {
            string name;
            string pw;
            bool done = false;
            do
            {
                Console.WriteLine();
                Console.WriteLine("LOGIN");
                Console.WriteLine();
                Console.Write("User name: ");
                name = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(name))
                {
                    continue;
                }
                Console.Write("Password: ");
                pw = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(pw))
                {
                    continue;
                }
                done = true;
            } while (!done);
            Console.WriteLine("Logging in ...");
        }
