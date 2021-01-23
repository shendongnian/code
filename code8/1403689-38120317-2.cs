    $"{"Hello World"}".PrintMe();
    public static class Extensions
    {
        public static void PrintMe(this object message)
        {
            Console.WriteLine("I am a " + message.GetType().FullName);
        }
    
        public static void PrintMe(this IFormattable message)
        {
                Console.WriteLine("I am a " + message.GetType().FullName);
        }
    }
