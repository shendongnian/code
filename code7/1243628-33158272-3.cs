Per your question in your comment below, you could make a static instance of your GameResults class in your Program class. Your code would end up looking something like the following
    class Program
    {
        private static GameResults results = new GameResults();
        
        public static void Main(string[] args)
        {
            // Code
        }
        private static bool PlayGame()
        {
            // Code
        }
    }
In PlayGame you would just use the static results object instead of creating a new one every time PlayGame is called. 
