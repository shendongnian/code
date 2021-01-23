    class Program
    {
        // A method that takes no input arguments but returns string
        private static string ReturnHelloWorld()
        {
            return "Hello World";
        }
        static void Main(string[] args)
        {
            MenuItem<string> menuItem = new MenuItem<string>();
            // FirstHandler signature is Func<T>
            // So it doesn't take any input arguments
            // and returns T - in our case string
            menuItem.FirstHandler = ReturnHelloWorld;
            // SecondHandler signature is Action<T>
            // So it takes one input argument of type T (here, string)
            // and returns void
            menuItem.SecondHandler = Console.WriteLine;
            // Now use a method of MenuItem class to invoke FirstHandler.
            string menuItemMessage = menuItem.DoSomething();
            // Use another method to invoke SecondHandler.
            menuItem.DoSomethingElse(menuItemMessage);
        }
    }
