    // Using your class name, not Singleton
    public class MyClass
    {
        // Public so the instance can be seen
        public static class MyClass _instance = new MyClass();
        // Private constructor so it doesn't create any more instances
        private MyClass() { }
        // The Public Property that intercepts the creation requests
        public MyClass Instance
        {
            get
            {
                if (_instance != null)
                    return _instance; // Pass back the single instance already created
                else
                {
                    MyClass _instance = new MyClass();
                    return _instance;
                }
            }
        }
        // Create the rest of your class
        public int myInt;
        public string myString;
    }
    
    // Access it in your program
    public MyClass myclass = MyClass._instance;
    
    public Main()
    {
        myclass.myString = "This is a string inside a Singleton instance of a class.";
        Console.WriteLine(myclass.myString);
    }
