        public static Task<int> DoLongOperationAsync()
        {
            return Task.Run(() => { Thread.Sleep(5000); return 5; }); // 5 seconds
        }
        public static async Task TestMethod()
        {
            var result = await DoLongOperationAsync();
            Console.WriteLine("Console");
            Console.WriteLine(result);
        }
        public static async Task TestMethod2()
        {
            var result = DoLongOperationAsync();
            Console.WriteLine("Console");
            Console.WriteLine(await result);
        }
        static async DoSomething()
        {
            await TestMethod(); // here you see some text in console only after 5 seconds
            await TestMethod2(); // here you see some text in console immediately and after 5 seconds you will see "5"
            
        }
