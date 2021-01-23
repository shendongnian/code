    class Program
    {
        private static void Main(string[] args)
        {
            CallAsync();
            Console.ReadKey();
        }
        public static async void CallAsync()
        {
            var task = CallExceptionAsync();
            ThrowException("Outside");
            await task;
        }
        public static Task CallExceptionAsync()
        {
            return Task.Run(() =>
            {
                ThrowException("Inside");
            });
        }
        public static void ThrowException(string msg)
        {
            throw new Exception(msg);
        }        
    }
