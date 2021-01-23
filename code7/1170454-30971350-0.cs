        static void Main(string[] args)
        {
            Dictionary<string, string> openWith = new Dictionary<string, string>
            {
                { "0xa", "This indicates that Microsoft Windows or a kernel-mode driver accessed\n" + 
                        "paged memory at DISPATCH_LEVEL or above.\n" },
                { "0xd1", "This indicates that a kernel-mode driver attempted to access pageable memory at\n" + 
                        "a process IRQL that was too high.\n" }
            };
            string userInput = "";
            while ((userInput = Console.ReadLine().ToLower()) != "exit")
            {                
                if (openWith.ContainsKey(userInput))
                    Console.WriteLine(openWith[userInput]);
                else
                    Console.WriteLine("Doesn't exist");
                Console.WriteLine("Type another bug check, or \"exit\" to quit:\n");
            }
        }
