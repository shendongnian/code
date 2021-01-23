    static void Main(string[] args) {
        while (true) {
            Console.WriteLine("Type \"server\" to start server, type \"client\" to start client, type \"exit\" to exit");
            string input = Console.ReadLine();
            if (input == "server") {
                Server server = new Server(IPAddress.Any, 12346);
            }
            else if (input == "client") {
                Client client = new Client(IPAddress.Parse("myipv4"), 12346);
            }
            else if (input == "exit")
                return;
        }
    }
