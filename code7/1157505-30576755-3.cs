        static void Main(string[] args)
        {
            CallWithAsync();
            Console.ReadKey();           
        }
        async static void CallWithAsync()
        {
            try
            {
                CancellationTokenSource source = new CancellationTokenSource();
                source.CancelAfter(TimeSpan.FromSeconds(1));
                var t1 = await GreetingAsync("Bulbul", source.Token);
            }
            catch (OperationCanceledException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        static Task<string> GreetingAsync(string name, CancellationToken token)
        {
            return Task.Run<string>(() =>
            {
                return Greeting(name, token);
            });
        }
        static string Greeting(string name, CancellationToken token)
        {
            Thread.Sleep(3000);
            token.ThrowIfCancellationRequested();
            return string.Format("Hello, {0}", name);
        }
