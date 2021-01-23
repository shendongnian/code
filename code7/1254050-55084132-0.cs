    // Using your class name, not Singleton
    public class MyClass
    {
        // Private to create a backer instance
        private static class MyClass _instance = new MyClass();
        // Private constructor so it doesn't create any more instances
        private MyClass() { }
        // The Public Property that intercepts the creation requests
        public MyClass Instance
        {
            get
            {
                return _instance; // Pass back the single instance already created
            }
        }
        // Create the rest of your class
        public int myInt;
        public string myString;
    }
    
    // Access it in your program
    public MyClass;
    
    public Main()
    {
        MyClass.myInt = 1;
        MyClass.myString = "This is a string inside a Singleton instance of a class.";
        
        Console.WriteLine(MyClass.myString);
    }
