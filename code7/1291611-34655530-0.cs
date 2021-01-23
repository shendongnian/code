    class MainClass
    { 
        public static void Main()
        {
            MyRecursiveFunction();
            AfterUserInput();
        }
        public static void MyRecursiveFunction()
        {
            if (userinput)
            { return; }
            // Waits 100 ticks to check again
            Thread.Sleep(new TimeSpan(100));
  
            MyRecursiveFunction();
        }
        public static void AfterUserInput()
        {
            // All that you need to do after the user input
        }
    }
