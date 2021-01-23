        private static void Main(string[] args)
        {
            var tokenSource = new CancellationTokenSource();
            CancellationToken token = tokenSource.Token;
            int timeOut = 10000; // 10 s
            string output = ""; // the return of the function will be stored here
            var task = Task.Factory.StartNew(() => output = function(), token);
            if (!task.Wait(timeOut, token))
                Console.WriteLine("The Task timed out!");
            Console.WriteLine("Done" + output);
        }
        private static string function()
        {
            Task.Delay(20000).Wait(); // assume function takes 20 s
            return "12345";
        }
