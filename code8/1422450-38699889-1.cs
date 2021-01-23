        static void Main(string[] args)
        {
            Console.WriteLine("Hallo, wie heißt du?");
            string name = nameCheck(console.ReadLine());
            if (name == string.Empty)
            {
                console.WriteLine(/* no name provided */);
                return;
            }
            /* other checking code */          
            Program a = new Program();
            Console.WriteLine("Hallo " + name);
            Console.ReadLine();
        }    
