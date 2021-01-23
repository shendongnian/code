        private static async Task SayHelloTwice()
        {
            var hellos = await Task.WhenAll(PrintTask(), PrintTask());
            Console.WriteLine(hellos[0]);
            Console.WriteLine(hellos[1]);
        }
