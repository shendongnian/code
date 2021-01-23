    private static string result;
    
        static void Main()
        {
            CallSaySomething();
            Console.WriteLine(result);
            Console.ReadLine();
        }
    
        static async Task<string> SaySomething()
        {
            await Task.Delay(5);
            result = "Hello world!";
            return "Something";
        }
    
        static string CallSaySomething()
        {
            var task = SaySomething();
            task.Wait();
    
            var result = task.Result;
            return result;
        }
