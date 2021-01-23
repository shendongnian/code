    public static class Functions
    {
        public static void Add()
        {
            Debug.Print("Add");
        }
        public static void Subtract()
        {
            Debug.Print("Subtract");
        }
        public enum Function
        {
            Add,
            Subtract
        }
        public static void Execute(Function function)
        {
            typeof(Functions).GetMethod(function.ToString()).Invoke(null, null);
        }
    }
